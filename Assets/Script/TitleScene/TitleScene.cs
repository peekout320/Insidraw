using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// TitleScene用のクラス、GameManagerにアタッチ
/// </summary>
public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private GameObject UnknownObjPrefab;
    [SerializeField]
    private Transform UnknownObjTran;

    [SerializeField]
    private Image imgTitle;
    [SerializeField]
    private Text txtDisplay;
    [SerializeField]
    private Image[] buttons;

    [SerializeField]
    private Text txtFlash;

    [SerializeField]
    private ParticleSystem[] particles;

    [SerializeField]
    private Material material1;
    [SerializeField]
    private float fadeSpeed = 5;

    [SerializeField]
    Fade fade;
    [SerializeField]
    private Texture fadeInTexture;

    [SerializeField]
    private Button btnStart;
    [SerializeField]
    private Button btnTutrial;

    [SerializeField]
    private bool startGameLoop;

    [SerializeField]
    private AudioClip startButtonSE;
    [SerializeField]
    private AudioClip tutrialButtonSE;
    [SerializeField]
    private AudioSource bgmAudio;


    void Start()
    {
        StartCoroutine(StartGame());

        btnStart.onClick.AddListener(() => StartCoroutine(ChangeScene()));
        btnTutrial.onClick.AddListener(() => StartCoroutine(ClickTutrialButton()));
    }

    /// <summary>
    /// ゲームスタート時にTitleScene用のオブジェクトを生成し、ボールとタイトルをフェードインする演出にする。
    /// BGMに合わせてボールが動き出す仕組みにしているが、WebGLは最初にゲーム画面をクリックしないと音が流れないので、
    /// WebGL用にクリックでボールが動き出すように設定している。
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartGame()
    {
        //TitleScene用のオブジェクトを生成
        Instantiate(UnknownObjPrefab, UnknownObjTran, false);

        //ボールとUIのフェードイン
        imgTitle.DOFade(0, 0);
        imgTitle.DOFade(1, fadeSpeed);

        txtDisplay.DOFade(0, 0);
        txtDisplay.DOFade(1, fadeSpeed);

        material1.DOFade(0, 0);
        material1.DOFade(1, fadeSpeed);

        //WebGL用にクリックするまで演出を待機する
        while (startGameLoop == true)
        {
            if (Input.GetMouseButton(0))
            {
                //BGMの再生
                bgmAudio.Play();

                //パーティクルを順番にアクティブにする
                particles[0].gameObject.SetActive(true);

                yield return new WaitForSeconds(0.85f);

                particles[1].gameObject.SetActive(true);

                yield return new WaitForSeconds(1.1f);

                particles[2].gameObject.SetActive(true);

                //ボールを動かす
                MovingBall_Title();

                //CinemachineCameraで演出
                vCam.enabled = true;

                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].DOFade(1, fadeSpeed);
                }

                startGameLoop = false;
            }
            yield return null;
        }
        //キー入力でボールに力を加える
        StartCoroutine(uiManager.KeyInputSlider());

        //特定のテキストを点滅させる
        StartCoroutine(uiManager.FlashText(6, txtFlash));
    }

    /// <summary>
    /// MainSceneに遷移する
    /// </summary>
    private IEnumerator ChangeScene()
    {
        AudioSource.PlayClipAtPoint(startButtonSE, Camera.main.transform.position,1);

        yield return new WaitForSeconds(2);

        uiManager.FadeInScreen(fadeInTexture);

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// チュートリアルボタンを押下時の処理
    /// </summary>
    private IEnumerator ClickTutrialButton()
    {
        AudioSource.PlayClipAtPoint(startButtonSE, Camera.main.transform.position, 1);

        yield return new WaitForSeconds(2);

        uiManager.FadeInScreen(fadeInTexture);

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("TutrialScene");
    }

    /// <summary>
    /// タイトル画面におけるボールの動作
    /// </summary>
    public void MovingBall_Title()
    {       
        for (int i = 0; i < ballCon.ballList.Count; i++)
        {
            ballCon.ballList[i].SpeedX = Random.Range(-5f, 5f);
            ballCon.ballList[i].SpeedY = Random.Range(-5f, 5f);
            ballCon.ballList[i].SpeedZ = Random.Range(-5f, 5f);

            Rigidbody rigid = ballCon.ballList[i].GetComponent<Rigidbody>();

            ballCon.AddrigidList(rigid);

            ballCon.IsMoving = true;
        }
        //Debug.Log(rigid.velocity.magnitude + "rigid.velocity");
    }
}
