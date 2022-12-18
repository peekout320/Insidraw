using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

/// <summary>
/// UIManagerにアタッチ
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider[] sliders;
    public Slider[] Sliders { get => sliders; }

    [SerializeField]
    private float addPower = 0.5f;

    [SerializeField]
    private BallController ballCon;

    private float startTime = 100;

    public ReactiveProperty<float> Timer = new ReactiveProperty<float>();

    public ReactiveProperty<float> Score = new ReactiveProperty<float>();

    public ReactiveProperty<float> SumScore = new ReactiveProperty<float>();

    public ReactiveProperty<Text> TxtAnswer = new ReactiveProperty<Text>();

    [SerializeField]
    private int stopTimerIndex; 

    /// <summary>
    /// キー入力をスライダーに反映
    /// </summary>
    /// <returns></returns>
    public IEnumerator KeyInputSlider()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            if (!Input.anyKey)
            {
                //Debug.Log("test1");

                ballCon.IsMoving = false;

                for (int i = 0; i < sliders.Length; i++)
                {
                    if (sliders[i].value > 0)
                    {
                        sliders[i].value -= addPower;

                        //Debug.Log("test2");
                    }
                    else
                    {
                        sliders[i].value += addPower;

                        //Debug.Log("test3");
                    }
                }
            }

            //X軸に対する値を変化させる
            if (Input.GetKey(KeyCode.R))
            {
                ballCon.IsMoving = true;

                sliders[0].value -= addPower;
            }

            if (Input.GetKey(KeyCode.T))
            {
                ballCon.IsMoving = true;

                sliders[0].value += addPower;
            }

            //Y軸に対する値を変化させる
            if (Input.GetKey(KeyCode.F))
            {
                ballCon.IsMoving = true;

                sliders[1].value += addPower;
            }

            if (Input.GetKey(KeyCode.G))
            {
                ballCon.IsMoving = true;

                sliders[1].value -= addPower;
            }

            //Z軸に対する値の変化
            if (Input.GetKey(KeyCode.V))
            {
                ballCon.IsMoving = true;

                sliders[2].value -= addPower;
            }

            if (Input.GetKey(KeyCode.B))
            {
                ballCon.IsMoving = true;

                sliders[2].value += addPower;
            }
            yield return null;
        }
    }

    /// <summary>
    /// 時間をスコアに代入
    /// </summary>
    public void DisplayScore()
    {
        Score.Value += Timer.Value;

        SumScore.Value = Timer.Value;
    }

    /// <summary>
    /// タイマーの開始、停止
    /// </summary>
    /// <param name="gameManager"></param>
    /// <returns></returns>
    public IEnumerator TimerStart(GameManager gameManager)
    {
        Timer.Value = startTime; 

        //正解するまでタイマーを動かすための変数を用意
        stopTimerIndex = gameManager.QuestionNO;

        while (true)
        {
            if (stopTimerIndex == gameManager.QuestionNO)
            {
                Timer.Value -= Time.deltaTime;
            }
            else
            {
                Timer.Value = Timer.Value;
            }
            yield return null;
        }
    }

    public void TimerReset()
    {
        DOVirtual.DelayedCall(5, () =>
         {
             Timer.Value = startTime;

             stopTimerIndex++;
         });
    }
}
