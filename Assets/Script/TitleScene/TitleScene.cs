using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private Transform appleTran;

    [SerializeField]
    private Ball ballPrefab;
    [SerializeField]
    private Transform ballTran;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private Generator generater;

    [SerializeField]
    private CinemachineVirtualCamera vCam;

    [SerializeField]
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBall_Title();
    }

    private void GenerateBall_Title()
    {
        Instantiate(applePrefab, appleTran, false);

        generater.GenerateBall();

        vCam.Follow = generater.GenerateBallList[0].transform;
        vCam.LookAt = generater.GenerateBallList[0].transform;

        StartCoroutine(uiManager.KeyInputSlider());
    }
}
