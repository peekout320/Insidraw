using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// BallControllerにアタッチ
/// </summary>
public class BallController : MonoBehaviour
{
    [SerializeField]
    private UIManager slider;

    private Rigidbody rigid;

    [SerializeField]
    private List<Rigidbody> rigidList = new List<Rigidbody>();

    public List<Ball> ballList = new List<Ball>();

    [SerializeField]
    private float limitSpeed = 5f;

    [SerializeField]
    private AudioClip colAudio;
    [SerializeField]
    private float audioVolum = 0.5f;

    [SerializeField]
    private bool isMoving;
    public bool IsMoving { get => isMoving; set => isMoving = value; }


    private void FixedUpdate()
    {
        if (!isMoving) return;
        for (int i = 0; i < ballList.Count; i++)
        {
            rigidList[i].velocity = Vector3.ClampMagnitude(rigidList[i].velocity, limitSpeed);

            rigidList[i].AddForce(new Vector3(ballList[i].SpeedX, ballList[i].SpeedY, ballList[i].SpeedZ), ForceMode.Force);
        }
    }
    /// <summary>
    /// ボールの初動。velocityに制限をつけてrigidbodyで動かす
    /// </summary>
    /// <param name="balls"></param>
    /// <returns></returns>
    public void MovingBall(List<Ball> balls)
    {
        this.ballList = balls;

        for (int i = 0; i < balls.Count; i++)
        {
            rigid = balls[i].GetComponent<Rigidbody>();

            AddrigidList();

            isMoving = true;
        }

        //Debug.Log(rigid.velocity.magnitude + "rigid.velocity");
    }

    /// <summary>
    /// ボールのRigidbody型のリストに追加
    /// </summary>
    private void AddrigidList()
    {
        rigidList.Add(rigid);
    }

    /// <summary>
    /// 他オブジェクトに接触時の反応
    /// </summary>
    public void OnCollision()
    {
        for (int i = 0; i < ballList.Count; i++)
        {
            ballList[i].OnCollisionEnterAsObservable()
                .Subscribe(col =>
                {
                    AudioSource.PlayClipAtPoint(colAudio, Camera.main.transform.position,audioVolum);
                })
                .AddTo(this);
        }
    }
}
