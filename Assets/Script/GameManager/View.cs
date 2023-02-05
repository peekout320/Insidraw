using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

/// <summary>
/// UIManagerへアタッチ
/// Canvasに表示するUIManagerの情報をPresenter経由で受け取り表示する
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

    /// <summary>
    /// スコアをUIManager/ReactivePropateyのScore変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="viewScore"></param>
    public void ViewScore(float viewScore)
    {
        txtScore.text = viewScore.ToString("F0");
    }

    /// <summary>
    /// スコアに加減される数値をUIManager/ReactivePropateyのScore変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="viewSumScore"></param>
    public void ViewSumScore(float viewSumScore)
    {
        if(viewSumScore > 0)
        {
            txtSumScore.text = "+" + viewSumScore.ToString("F0");
            txtSumScore.color = Color.green;
        }
        else
        {
            txtSumScore.text = viewSumScore.ToString("F0");
            txtSumScore.color = Color.red;
        }

        //string a = viewSumScore > 0 ? "+"  : "";
        //txtSumScore.text = "+" + viewSumScore.ToString("F0");

        //加減されるポイントを表示して、5秒後に消す
        txtSumScore.gameObject.SetActive(true);

        DOVirtual.DelayedCall(5, () =>
         {
             txtSumScore.gameObject.SetActive(false);
         });
    }

    /// <summary>
    /// 制限時間をUIManager/ReactivePropateyのTimer変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="viewTimer"></param>
    public void ViewTimer(float viewTimer)
    {
        txtTimer.text = viewTimer.ToString("F0");
    }

    /// <summary>
    /// 出題の答えをUIManager/ReactivePropateyのStrAnswer変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="viewAnswer"></param>
    public void ViewTextAnswer(string viewAnswer)
    {
        txtAnswer.text = "A. " + viewAnswer;
    }

    /// <summary>
    /// 問題番号をUIManager/ReactivePropateyのquestionNoIndex変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="questionNo"></param>
    public void ViewQuestionNo(int questionNo)
    {
        txtquetionNo.text = questionNo.ToString();
    }

    /// <summary>
    /// チュートリアルでの説明文をUIManager/ReactivePropateyのStrTutrial変数をPresenter経由で受け取り表示する
    /// </summary>
    /// <param name="telop"></param>
    public void ViewTutrialTelop(string telop)
    {
        txtTelop.text = telop;
    }
}
