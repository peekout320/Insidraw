using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// カメラを回転すると、ボールパワーの”横”と”奥”がわかり辛くなるので方向が分かりやすくなるように設置したCompassにアタッチする
/// </summary>
public class CompassController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        //コンパス自体はMainCameraの子にして追随するようにし、compass自体は初期値から回転しないように設定する
        var compassTran = this.transform.rotation;

        Observable.EveryUpdate()
            //.Where(_ => Input.anyKey)
            .Subscribe(_ =>
            {
                this.transform.rotation = compassTran;
            });

        //this.UpdateAsObservable()
        //    .Where(_ => Input.anyKey)
        //    .Subscribe(_ =>
        //    {
        //        this.transform.rotation = Quaternion.Euler(new Vector3(2.7f, 58.7f, 0));
        //    });
    }
}
