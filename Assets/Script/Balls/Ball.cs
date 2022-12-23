using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// prefab　⇨　Ballにアタッチ
/// </summary>
public class Ball : MonoBehaviour
{
    private float speedX;
    public float SpeedX { get => speedX; set => speedX = value; }

    private float speedY;
    public float SpeedY { get => speedY; set => speedY = value; }

    private float speedZ;
    public float SpeedZ { get => speedZ; set => speedZ = value; }

    //public ReactiveProperty<float> BallSpeedX = new ReactiveProperty<float>();
    //public ReactiveProperty<float> BallSpeedY = new ReactiveProperty<float>();
    //public ReactiveProperty<float> BallSpeedZ = new ReactiveProperty<float>();

    //public List<float> BallSpeeds = new List<float>();

    void Start()
    {
        speedX = Random.Range(-3f, 3f);
        speedY = Random.Range(-3f, 3f);
        speedZ = Random.Range(-3f, 3f);

        Debug.Log("speedX" + speedX);

        //BallSpeeds.Add(speedX);
        //BallSpeeds.Add(speedY);
        //BallSpeeds.Add(speedZ);

        //BallSpeedX.Value = Random.Range(-0.5f, 0.5f);
        //BallSpeedY.Value = Random.Range(-0.5f, 0.5f);
        //BallSpeedZ.Value = Random.Range(-0.5f, 0.5f);

        //BallSpeeds.Add(BallSpeedX.Value);
        //BallSpeeds.Add(BallSpeedY.Value);
        //BallSpeeds.Add(BallSpeedZ.Value);
    }
}


