using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class Presenter : MonoBehaviour
{
    [SerializeField]
    private View view;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private BallController ballcon;


    /// <summary>
    /// GameManagerのStart関数より少し間を持たせてからセットアップ開始
    /// </summary>
    /// <returns></returns>
    public void SetupPresenter()
    {
        ReflectSliderValue();
        ReflectTimer();
        ReflectScore();
        ReflectSumScore();
        ReflectAnswer();
        ReflectQuestionNo();
        ReflectGameOverText();
    }

    /// <summary>
    /// スライダーのvalueをボールのvelocityへ反映させる。
    /// </summary>
    private void ReflectSliderValue()
    {
        for (int i = 0; i < uiManager.Sliders.Length; i++)
        {
            int a = i;

            uiManager.Sliders[0].OnValueChangedAsObservable()
              .Subscribe(sliderValue => ballcon.ballList[a].SpeedY = sliderValue).AddTo(this);

            uiManager.Sliders[1].OnValueChangedAsObservable()
                  .Subscribe(sliderValue => ballcon.ballList[a].SpeedX = sliderValue).AddTo(this);

            uiManager.Sliders[2].OnValueChangedAsObservable()
                  .Subscribe(sliderValue => ballcon.ballList[a].SpeedZ = sliderValue).AddTo(this);
        }
    }

    /// <summary>
    /// UIManager(Model)クラスのタイマー変数をViewクラスへ反映させる
    /// </summary>
    private void ReflectTimer()
    {
        uiManager.Timer.Subscribe(x => view.ViewTimer(x) ).AddTo(this);
    }

    /// <summary>
    /// UIManager(Model)クラスのスコア変数をViewクラスへ反映させる
    /// </summary>
    private void ReflectScore()
    {
        uiManager.Score.Subscribe(x => view.ViewScore(x)).AddTo(this);
    }

    /// <summary>
    /// UIManager(Model)クラスの加算スコア変数をViewクラスへ反映させる
    /// </summary>
    private void ReflectSumScore()
    {
        uiManager.SumScore.Subscribe(x => view.ViewSumScore(x)).AddTo(this);
    }

    /// <summary>
    /// UIManager(Model)クラスの問題の答えのstring変数をViewクラスへ反映させる
    /// </summary>
    private void ReflectAnswer()
    {
        uiManager.StrAnswer.Subscribe(x => view.ViewTextAnswer(x)).AddTo(this);
    }

    /// <summary>
    /// UIManager(Model)クラスの問題番号int変数をViewクラスへ反映させる
    /// </summary>
    private void ReflectQuestionNo()
    {
        uiManager.questionNoIndex.Subscribe(x => view.ViewQuestionNo(x)).AddTo(this);
    }

    /// <summary>
    /// UIManager(Model)クラスのゲームオーバー時に表示するテキストをViewクラスへ反映させる
    /// </summary>
    private void ReflectGameOverText()
    {
        uiManager.questionNoIndex.Subscribe(x => StartCoroutine(uiManager.GameOver(x))).AddTo(this);
    }

    /// <summary>
    /// チュートリアルでのテロップをViewクラスへ反映させる
    /// </summary>
    public void ReflectTutrialTelop()
    {
        uiManager.StrTutrial.Subscribe(x => view.ViewTutrialTelop(x)).AddTo(this);
    }
}
