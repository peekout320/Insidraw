using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// ボールに加える力の数値を設定
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

    private float ballPower = 1f;

    void Start()
    {
        speedX = Random.Range(-ballPower, ballPower);
        speedY = Random.Range(-ballPower, ballPower);
        speedZ = Random.Range(-ballPower, ballPower);

        //Debug.Log("speedX" + speedX);
    }
}


