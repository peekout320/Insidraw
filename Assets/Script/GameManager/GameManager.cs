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
    public int QuestionNO { get => questionNo; set => questionNo = value; }

    [SerializeField]
    private SplineController CollectSpline;

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

        //問題番号を表示
        uiManager.DisplayQuestionNo();
    }

    public void JudgeString()
    {
        if (view.InputForm.text == DataBaseManager.instance.objectDataSO.objrctDataList[questionNo].name)
        {
            Debug.Log("正解");

            //答えを表示
            uiManager.DisplayAnswer(5);

            //次の問題番号を取得
            questionNo++;

            //タイマーストップ
            uiManager.TimerReset(5);

            //スコアを加算
            uiManager.DisplayScore();

            //正解のSE
            AudioSource.PlayClipAtPoint(trueAudio,Camera.main.transform.position);

            //◯を描画
            StartCoroutine(CollectSpline.OnSpline());

            Debug.Log("test");

            //数秒おいて次のオブジェクトに切り替える
            DOVirtual.DelayedCall(5, () =>
            {
                NextQuestionPreparate();
             });
        }
        else
        {
            Debug.Log("不正解");

            //不正解SE
            AudioSource.PlayClipAtPoint(falseAudio, Camera.main.transform.position);
        }
    }

    /// <summary>
    /// 次の問題へ移行するための準備
    /// </summary>
    public void NextQuestionPreparate()
    {
        //入力フォームを消去
        view.InputForm.text = null;

        //パーティクルを解除
        generator.OffParticle();

        //現在のUnkownObjectを破棄
        generator.DestroyUnknownObject();

        //スプラインを再設置
        CollectSpline.OffSpline();

        //ボールを再設定
        generator.Re_SetupGenerateBalls();

        DOVirtual.DelayedCall(0.5f, () =>
        {

            //次のUnkownObjectを設置
            generator.GenerateUnknownObject(this);

            //パーティクル再始動
            generator.OnParticle();

            //問題番号更新
            uiManager.DisplayQuestionNo();
        });
    }

}
