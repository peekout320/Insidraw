using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;
using Cinemachine;

/// <summary>
/// MainCamera -> Splineにアタッチ
/// </summary>
public class SplineController : MonoBehaviour
{
    [SerializeField]
    ParticleSystem partical;

    //スプラインの内部を操作する変数
    [SerializeField]
    private SplineContainer splineConta;

    //スプラインの描画位置
    [SerializeField]
    private Transform splineObj;

    //スプラインの現在位置情報
    [SerializeField,Range(0,1)]
    private float splinePos;

    //スプラインの移動スピード
    [SerializeField]
    private float splineSpeed = 0.02f;

    [SerializeField]
    private CinemachineBrain Cam;


    /// <summary>
    /// 正解時に○をスプラインで描画する
    /// </summary>
    public IEnumerator OnSpline()
    {
        //スプライン時はカメラ操作できなくする
        Cam.enabled = false;

        partical.gameObject.SetActive(true);

        for (float i = 0; i < 1; i += 0.001f)
        {
            splinePos += i;

            Debug.Log(splinePos);

            //EvaluatePosition(0~1)でスプラインの軌道と指定のオブジェクトの動きを同期させる
            splineObj.position = splineConta.EvaluatePosition(splinePos);

             yield return new WaitForSeconds(splineSpeed);

            //splinePOsが１になったらfor文ループを抜ける
            if(splinePos >= 1)
             yield break;
        }
    }

    /// <summary>
    /// スプラインを再描画できる状態に戻す
    /// </summary>
    public void OffSpline()
    {
        partical.gameObject.SetActive(false);

        Cam.enabled = true;

        splinePos = 0;

        splineObj.position = splineConta.EvaluatePosition(0);
    }
}
