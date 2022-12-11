using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Ball : MonoBehaviour
{
    private float speedX = 0.2f;
    public float SpeedX { get => speedX; set => speedX = value; }

    private float speedY = 0.2f;
    public float SpeedY { get => speedY; set => speedY = value; }

    private float speedZ = 0.2f;
    public float SpeedZ { get => speedZ; set => speedZ = value; }

    //public ReactiveProperty<float> BallSpeedX = new ReactiveProperty<float>();
    //public ReactiveProperty<float> BallSpeedY = new ReactiveProperty<float>();
    //public ReactiveProperty<float> BallSpeedZ = new ReactiveProperty<float>();

    //public List<float> BallSpeeds = new List<float>();


    public void SetupBall()
    {
        speedX = Random.Range(-0.5f, 0.5f);
        speedY = Random.Range(-0.5f, 0.5f);
        speedZ = Random.Range(-0.5f, 0.5f);

        //BallSpeedX.Value = Random.Range(-0.5f, 0.5f);
        //BallSpeedY.Value = Random.Range(-0.5f, 0.5f);
        //BallSpeedZ.Value = Random.Range(-0.5f, 0.5f);

        //BallSpeeds.Add(BallSpeedX.Value);
        //BallSpeeds.Add(BallSpeedY.Value);
        //BallSpeeds.Add(BallSpeedZ.Value);
    }
}


