using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    private Sample_Model sampleModel;

    [SerializeField]
    private Sample_View sampleView;

    [SerializeField]
    private BallController ballcon;

    [SerializeField]
    private SliderController slider;


    // Start is called before the first frame update
    void Start()
    {
        //
        //for (int i = 0; i < slider.Sliders.Length; i++)
        //{
        //    slider.Sliders[i].OnValueChangedAsObservable()
        //        .Subscribe(sliderValue => ballcon.balls[i].BallSpeeds[i] = sliderValue).AddTo(this);

        //    //sampleModel.BallSpeedX.Subscribe(speed => ballcon.balls[i].BallSpeeds[i] = speed).AddTo(this);
        //}
        sampleView.sliderX.OnValueChangedAsObservable()
         .Subscribe(sliderValue => ballcon.balls[0].SpeedX = sliderValue).AddTo(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
