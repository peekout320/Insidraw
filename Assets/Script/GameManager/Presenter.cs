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
    private BallController ballcon;

    [SerializeField]
    private UIManager uiManager;


    void Start()
    {
        ReflectSliderValue();
        ReflectTimer();
        ReflectScore();
        ReflectSumScore();
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
              .Subscribe(sliderValue => ballcon.ballList[a].SpeedX = sliderValue).AddTo(this);
            uiManager.Sliders[1].OnValueChangedAsObservable()
                  .Subscribe(sliderValue => ballcon.ballList[a].SpeedY = sliderValue).AddTo(this);
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
}
