using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    //[SerializeField]
    //private Sample_Model sampleModel;

    //[SerializeField]
    //private Sample_View sampleView;

    [SerializeField]
    private BallController ballcon;

    [SerializeField]
    private SliderController slider;

    void Start()
    {
        for (int i = 0; i < slider.Sliders.Length; i++)
        {
            int a = i;
            slider.Sliders[0].OnValueChangedAsObservable()
              .Subscribe(sliderValue => ballcon.balls[a].SpeedX = sliderValue).AddTo(this);
            slider.Sliders[1].OnValueChangedAsObservable()
                  .Subscribe(sliderValue => ballcon.balls[a].SpeedY = sliderValue).AddTo(this);
            slider.Sliders[2].OnValueChangedAsObservable()
                  .Subscribe(sliderValue => ballcon.balls[a].SpeedZ = sliderValue).AddTo(this);
        }


        //for (int i = 0; i < slider.Sliders.Length; i++)
        //{
        //    int a = i;
        //    slider.Sliders[a].OnValueChangedAsObservable()
        //        .Subscribe(sliderValue => ballcon.balls[a].BallSpeeds[a] = sliderValue).AddTo(this);
        //}
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //    for (int i = 0; i < slider.Sliders.Length; i++)
    //    {
    //        slider.Sliders[i].OnValueChangedAsObservable()
    //            .Subscribe(sliderValue => ballcon.balls[i].BallSpeeds[i] = sliderValue).AddTo(this);

    //        //sampleModel.BallSpeedX.Subscribe(speed => ballcon.balls[i].BallSpeeds[i] = speed).AddTo(this);
    //    }
    //    //sampleView.sliderX.OnValueChangedAsObservable()
    //    // .Subscribe(sliderValue => ballcon.balls[0].SpeedX = sliderValue).AddTo(this);

    //}
}
