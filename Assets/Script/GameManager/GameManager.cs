using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private Generator generator;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private View view;

    [SerializeField]
    private int questionNo;
    public int QuestionNO { get => questionNo; }

    [SerializeField]
    private SplineController splineCon;

    [SerializeField]
    private AudioClip trueAudio;
    [SerializeField]
    private AudioClip falseAudio;


    private void Start()
    {
        //問題となるオブジェクトの生成
        generator.GenerateUnknownObject(this);

        //ボール生成
        generator.GenerateBall();

        //タイマー始動
        StartCoroutine(uiManager.TimerStart(this));

        //キー入力をスライダーに反映
        StartCoroutine(uiManager.KeyInputSlider());
    }

    public void JudgeString()
    {
        if (view.InputForm.text == DataBaseManager.instance.objectDataSO.objrctDataList[questionNo].name)
        {
            Debug.Log("正解");

            //次の問題番号を取得
            questionNo++;

            //タイマーストップ
            uiManager.TimerReset();

            //スコアを加算
            uiManager.DisplayScore();

            //正解のSE
            AudioSource.PlayClipAtPoint(trueAudio,Camera.main.transform.position);

            //◯を描画
            StartCoroutine(splineCon.OnSpline());

            Debug.Log("test");

            //数秒おいて次のオブジェクトに切り替える
            DOVirtual.DelayedCall(5, () =>
            {
                 //現在のUnkownObjectを破棄
                 generator.DestroyUnknownObject();

                 //スプラインを再設置
                 splineCon.OffSpline();

                 //ボールを再設定
                 generator.Re_SetupGenerateBalls();

                 DOVirtual.DelayedCall(0.5f, () =>
                 {
                     //次のUnkownObjectを設置
                     generator.GenerateUnknownObject(this);
                 });

             });
        }
        else
        {
            Debug.Log("不正解");

            //不正解SE
            AudioSource.PlayClipAtPoint(falseAudio, Camera.main.transform.position);
        }
    }

}
