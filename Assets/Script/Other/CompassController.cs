using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// カメラを回転するとローカル視点でのZ軸とX軸が混同するので、方向が分かりやすくなるように設置したCompassにアタッチする
/// </summary>
public class CompassController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        //コンパス自体はMainCameraの子にして追随するようにするが、回転はしないように設定する
        var compassTran = this.transform.rotation;

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                this.transform.rotation = compassTran;
            });

        //その他の記述の仕方
        //Observable.EveryUpdate()
        //    .Where(_ => Input.anyKey)
        //    .Subscribe(_ =>
        //    {
        //        this.transform.rotation = compassTran;
        //    })
        //    .AddTo(this);

    }
}
