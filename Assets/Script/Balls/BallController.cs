using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ボールの移動に関す処理、接触時の処理
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
    private AudioClip colAudio;

    [SerializeField]
    private bool isMoving;
    public bool IsMoving { get => isMoving; set => isMoving = value; }


    /// <summary>
    /// ボールの初動。isMovingをtrueにしてFixedUpdat内でAddForceする。
    /// </summary>
    /// <param name="balls"></param>
    /// <returns></returns>
    public void MovingBall(List<Ball> balls)
    {
        this.ballList = balls;

        for (int i = 0; i < balls.Count; i++)
        {
            rigid = balls[i].GetComponent<Rigidbody>();

            AddrigidList(rigid);

            isMoving = true;
        }
    }
    private void FixedUpdate()
    {
        if (!isMoving) return;

        //ボールの速度制限値
        float limitSpeed = 5f;

        for (int i = 0; i < ballList.Count; i++)
        {
            //velocityに制限をつけてrigidbodyで動かす
            rigidList[i].velocity = Vector3.ClampMagnitude(rigidList[i].velocity, limitSpeed);

            rigidList[i].AddForce(new Vector3(ballList[i].SpeedX, ballList[i].SpeedY, ballList[i].SpeedZ), ForceMode.Force);
        }
    }

    /// <summary>
    /// ボールのRigidbody型のリストに追加
    /// </summary>
    public void AddrigidList(Rigidbody rigidbody)
    {
        rigidList.Add(rigidbody);
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
                    //ボール接触時の効果音量
                    float audioVolum = 0.5f;

                    AudioSource.PlayClipAtPoint(colAudio, Camera.main.transform.position,audioVolum);
                })
                .AddTo(this);
        }
    }
}
