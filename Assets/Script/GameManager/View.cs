using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// UIManagerへアタッチ
/// </summary>
public class View : MonoBehaviour
{
    [SerializeField]
    private InputField inputForm;
    public InputField InputForm { get => inputForm; }

    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private Text txtSumScore;

    [SerializeField]
    private Text txtTimer;

    [SerializeField]
    private Text txtAnswer;

    [SerializeField]
    private Text txtquetionNo;

    [SerializeField]
    private Text txtTelop;


    public void ViewScore(float viewScore)
    {
        txtScore.text = viewScore.ToString("F0");
    }

    public void ViewSumScore(float viewSumScore)
    {
        txtSumScore.text = "+" + viewSumScore.ToString("F0");

        txtSumScore.gameObject.SetActive(true);

        DOVirtual.DelayedCall(5, () =>
         {
             txtSumScore.gameObject.SetActive(false);
         });
    }

    public void ViewTimer(float viewTimer)
    {
        txtTimer.text = viewTimer.ToString("F0");
    }

    public void ViewTextAnswer(string viewAnswer)
    {
        txtAnswer.text = "A. " + viewAnswer;
    }

    public void ViewQuestionNo(int questionNo)
    {
        txtquetionNo.text = questionNo.ToString();
    }

    public void ViewTutrialTelop(string telop)
    {
        txtTelop.text = telop;
    }
}
