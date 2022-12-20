using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private Transform appleTran;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Image[] imgDislay;

    [SerializeField]
    private Material material1;

    [SerializeField]
    private float fadeSpeed = 5;

    [SerializeField]
    private AudioClip bgmAudio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveStartBall_Title());
    }

    private IEnumerator MoveStartBall_Title()
    {
        Instantiate(applePrefab, appleTran, false);

        for(int i = 0;i < ballCon.ballList.Count; i++)
        {
            imgDislay[i].DOFade(0, 0);

            imgDislay[i].DOFade(1, fadeSpeed);

            material1.DOFade(0, 0);

            material1.DOFade(1, fadeSpeed);

        }

        yield return new WaitForSeconds(3);

        AudioSource.PlayClipAtPoint(bgmAudio, vCam.transform.position, 1f);

        yield return new WaitForSeconds(2);

        ballCon.MovingBall(ballCon.ballList);

        vCam.Follow = ballCon.ballList[0].transform;
        vCam.LookAt = ballCon.ballList[0].transform;

        StartCoroutine(uiManager.KeyInputSlider());
    }
}
