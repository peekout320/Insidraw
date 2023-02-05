using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ヒントとして、時間経過でオブジェクトの特定のパーツが浮かび上がってくるようにする
/// Prefab  -> UnkownObject -> 各Objectの胴体となるオブジェクトにアタッチ
/// </summary>
public class HintObjController : MonoBehaviour
{
    [SerializeField]
    private Material material1;

    [SerializeField]
    private Material material2;

    [SerializeField]
    private Material material3;

    [SerializeField]
    private float fadeSpeed = 120;


    // Start is called before the first frame update
    void Start()
    {
        FadeInObj();
    }

    /// <summary>
    /// オブジェクトの特定のパーツが浮かび上がってくるようにMaterialのAlph値を変化させる
    /// </summary>
    private void FadeInObj()
    {
        material1.DOFade(0, 0);
        material2.DOFade(0, 0);
        material3.DOFade(0, 0);

        material1.DOFade(1, fadeSpeed);
        material2.DOFade(1, fadeSpeed);
        material3.DOFade(1, fadeSpeed);
    }
}
