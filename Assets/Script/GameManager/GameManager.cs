using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームスタート時の処理、問題の答えの正誤を監視、次の問題への移行の処理
/// GameManagerにアタッチ
/// </summary>
public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private Generator generator;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Presenter presenter;

    [SerializeField]
    private View view;

    [SerializeField]
    private Text txtGameStart;

    [SerializeField]
    private SplineController CollectSpline;

    [SerializeField]
    private int questionNo;
    public int QuestionNO { get => questionNo; set => questionNo = value; }

    [SerializeField]
    private AudioClip trueAudio;
    [SerializeField]
    private AudioClip falseAudio;


    private void Start()
    {
        StartCoroutine(StartGame());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartGame()
    {
        //[GameStart]を画面に表示する
        uiManager.ShowUpText(txtGameStart,6);

        //演出のため数秒、間を持たせてからゲームを開始する。
        yield return new WaitForSeconds(3);

        //問題となる透明なオブジェクトの生成
        generator.GenerateUnknownObject(this);

        //ボール生成
        generator.GenerateBall();

        //タイマー(制限時間)始動
        StartCoroutine(uiManager.TimerStart(this));

        //キー入力をスライダーに反映
        StartCoroutine(uiManager.KeyInputSlider());

        //問題番号を表示
        uiManager.DisplayQuestionNo();

        //ゲームスタート時から必要なModelを登録
        presenter.SetupPresenter();
    }

    /// <summary>
    /// InputFieldに入力した答えとの整合を行う
    /// </summary>
    public void JudgeString()
    {
        if (view.InputForm.text == DataBaseManager.instance.objectDataSO.objrctDataList[questionNo].name)
        {
            Debug.Log("正解");

            //答えを表示
            uiManager.DisplayAnswer(5);

            //次の問題番号を取得
            questionNo++;

            //スコアを加算
            uiManager.DisplayPlusScore();

            //正解のSE
            AudioSource.PlayClipAtPoint(trueAudio,Camera.main.transform.position);

            //◯を描画
            StartCoroutine(CollectSpline.OnSpline());

            Debug.Log("test");

            //数秒おいてタイマーをリセットし次のオブジェクトに切り替える
            DOVirtual.DelayedCall(5, () =>
            {
                uiManager.TimerReset();

                NextQuestionPreparate();
             });
        }
        else
        {
            Debug.Log("不正解");

            //不正解SE
            AudioSource.PlayClipAtPoint(falseAudio, Camera.main.transform.position);

            uiManager.DisplayMinusScore();

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
        generator.ReSetupGenerateBalls();

        DOVirtual.DelayedCall(TIME_DATA.NEXT_QUESTION_PREPARATE_TIME, () =>
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
