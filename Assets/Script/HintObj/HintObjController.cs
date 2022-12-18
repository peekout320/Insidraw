using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// UnkownObject -> 球.001にアタッチ
/// </summary>
public class HintObjController : MonoBehaviour
{
    [SerializeField]
    private Material material1;

    [SerializeField]
    private Material material2;

    // Start is called before the first frame update
    void Start()
    {
        FadeInObj();
    }

    private void FadeInObj()
    {
        material1.DOFade(0, 0);
        material2.DOFade(0, 0);

        material1.DOFade(1, 60);
        material2.DOFade(1, 60);
    }
}
