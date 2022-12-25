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
    private GameObject UnknownObjPrefab;
    [SerializeField]
    private Transform UnknownObjTran;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Image[] imgDisplay;

    [SerializeField]
    private Text txtDisplay;

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
    private AudioClip startButtonSE;

    [SerializeField]
    private AudioClip tutrialButtonSE;

    [SerializeField]
    private AudioSource bgmAudio;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());

        btnStart.onClick.AddListener(() => StartCoroutine(ChangeScene()));
        btnTutrial.onClick.AddListener(() => ClickTutrialButton());
    }

    private IEnumerator StartGame()
    {
        //UnknownObjectの生成
        Instantiate(UnknownObjPrefab, UnknownObjTran, false);

        //ボールとUIのフェードイン
        for (int i = 0; i < ballCon.ballList.Count; i++)
        {
            imgDisplay[i].DOFade(0, 0);
            imgDisplay[i].DOFade(1, fadeSpeed);
        }

        txtDisplay.DOFade(0, 0);
        txtDisplay.DOFade(1, fadeSpeed);

        material1.DOFade(0, 0);
        material1.DOFade(1, fadeSpeed);
        

        yield return new WaitForSeconds(3);

        //BGMの再生
        bgmAudio.Play();

        yield return new WaitForSeconds(2);

        //ボールを動かす
        MovingBall_Title();

        //CinemachineCameraで演出
        vCam.enabled = true;

        //キー入力でボールに力を加える
        StartCoroutine(uiManager.KeyInputSlider());
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

    private void ClickTutrialButton()
    {
        AudioSource.PlayClipAtPoint(tutrialButtonSE, Camera.main.transform.position,1);
    }

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
