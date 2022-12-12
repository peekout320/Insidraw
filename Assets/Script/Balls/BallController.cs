using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private SliderController slider;

    private Rigidbody rigid;

    [SerializeField]
    private List<Rigidbody> rigids = new List<Rigidbody>();

    public List<Ball> balls = new List<Ball>();

    [SerializeField]
    private float limitSpeed = 5f;

    [SerializeField]
    private bool isMoving = false;


    private void FixedUpdate()
    {
        if (!isMoving) return;
        for (int i = 0; i < balls.Count; i++)
        {
            rigids[i].velocity = Vector3.ClampMagnitude(rigids[i].velocity, limitSpeed);

            rigids[i].AddForce(new Vector3(balls[i].SpeedX, balls[i].SpeedY, balls[i].SpeedZ), ForceMode.Force);
            //rigids[i].AddForce(new Vector3(balls[i].BallSpeedX.Value, balls[i].BallSpeedY.Value, balls[i].BallSpeedZ.Value), ForceMode.Force);
        }
    }
    /// <summary>
    /// ボールの初動。velocityに制限をつけてrigidbodyで動かす
    /// </summary>
    /// <param name="balls"></param>
    /// <returns></returns>
    public void MovingBall(List<Ball> balls)
    {
        this.balls = balls;

        for (int i = 0; i < balls.Count; i++)
        {
            rigid = balls[i].GetComponent<Rigidbody>();

            Addrigids();

            isMoving = true;
        }

        //Debug.Log(rigid.velocity.magnitude + "rigid.velocity");
    }

    /// <summary>
    /// ボールのRigidbody型のリストに追加
    /// </summary>
    private void Addrigids()
    {
        rigids.Add(rigid);
    }

    /// <summary>
    /// スライダーの値をボールの動力へ反映する
    /// </summary>
    /// <param name="ballGene"></param>
    //public IEnumerator OutputBallPower(List<Ball> balls)
    //{
    //    while (balls != null)
    //    {
    //        for (int i = 0; i < balls.Count; i++)
    //        {
    //            balls[i].SpeedX = slider.Sliders[0].value;
    //            balls[i].SpeedY = slider.Sliders[1].value;
    //            balls[i].SpeedZ = slider.Sliders[2].value;
    //        }
    //        yield return null;
    //    }
    //}
}
