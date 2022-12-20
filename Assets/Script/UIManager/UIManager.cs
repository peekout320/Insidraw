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
    private GameManager gameManager;

    [SerializeField]
    private Slider[] sliders;
    public Slider[] Sliders { get => sliders; }

    [SerializeField]
    private float addPower = 0.5f;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private Text txtAnswer;

    [SerializeField]
    private Text txtTimeUp;

    [SerializeField]
    private int stopTimerIndex;

    [SerializeField]
    private float startTime = 100;

    public ReactiveProperty<int> questionNoIndex = new ReactiveProperty<int>();

    public ReactiveProperty<float> Timer = new ReactiveProperty<float>();

    public ReactiveProperty<float> Score = new ReactiveProperty<float>();

    public ReactiveProperty<float> SumScore = new ReactiveProperty<float>();

    public ReactiveProperty<string> StrAnswer = new ReactiveProperty<string>();


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

                sliders[1].value -= addPower;
            }

            if (Input.GetKey(KeyCode.G))
            {
                ballCon.IsMoving = true;

                sliders[1].value += addPower;
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
    /// タイマーの開始、停止
    /// </summary>
    /// <param name="gameManager"></param>
    /// <returns></returns>
    public IEnumerator TimerStart(GameManager gameManager)
    {
        this.gameManager = gameManager;

        Timer.Value = startTime; 

        //今の問題番号とタイマーを操作するための変数を同期する
        stopTimerIndex = gameManager.QuestionNO;

        while (true)
        {
            //制限時間を超えたらタイマーを止めて次の問題へ移行する
            if (Timer.Value <= 0)
            {
                DisplayAnswer(6);

                gameManager.QuestionNO++;

               //Debug.Log("timeup2");

                //TimeUPを表示
                DisplayTimeUp();
              
                TimerReset(6);

                DOVirtual.DelayedCall(6, () =>
                {
                    //Debug.Log("timeup3");
                    gameManager.NextQuestionPreparate();
                });

                //if文がループしないようにTimerを一旦0以上にする               
                Timer.Value = 0.1f;
            }

            //正解するまでタイマーを動かす
            if (stopTimerIndex == gameManager.QuestionNO)
            {
                Timer.Value -= Time.deltaTime;
            }
            //正解したらタイマーを止める
            else
            {
                Timer.Value = Timer.Value;
            }
            yield return null;
        }
    }

    /// <summary>
    /// タイマーの再開
    /// </summary>
    public void TimerReset(int waitSeconds)
    {
        DOVirtual.DelayedCall(waitSeconds, () =>
         {
             //タイマーを初期値に戻す
             Timer.Value = startTime;

             //問題番号と数値を一致させる
             stopTimerIndex++;
         });
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
    /// 答えを表示する。
    /// </summary>
    public void DisplayAnswer(int displayTime)
    {
        txtAnswer.gameObject.SetActive(true);

        Debug.Log(gameManager.QuestionNO);

        StrAnswer.Value = DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].name;

            DOVirtual.DelayedCall(displayTime, () =>
            {
                txtAnswer.gameObject.SetActive(false);
            });
    }

    /// <summary>
    /// 問題番号を表示する。
    /// </summary>
    public void DisplayQuestionNo()
    {
        questionNoIndex.Value = DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].Number;
    }

    /// <summary>
    /// 時間切れになった時に表示
    /// </summary>
    public void DisplayTimeUp()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(txtTimeUp.DOFade(1, 3))
            .Join(txtTimeUp.transform.DOScale(5, 5))

            .Join(DOVirtual.DelayedCall(6, () =>
            {
                txtTimeUp.DOFade(0, 0);
                txtTimeUp.transform.DOScale(1, 0);
            }));
    }
}
