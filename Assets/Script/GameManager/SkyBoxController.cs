using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField]
    private Material sky;

    // Start is called before the first frame update
    void Start()
    {
        SetupSkyBox();
    }

    /// <summary>
    /// 背景を回転させる
    /// </summary>
    /// <param name="stageLevelIndex"></param>
    private void SetupSkyBox()
    {
        RenderSettings.skybox = sky;

        sky.SetFloat("_Rotation", 360);

        //SkyBoxマテリアルを回転させる
        sky.DOFloat(0, "_Rotation", 90)
            .SetLoops(-1, LoopType.Restart)
            .SetLink(gameObject);

        //Debug.Log("スカイボックス");
    }

}
