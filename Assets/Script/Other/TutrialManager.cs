using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutrialManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Presenter presenter;

    void Start()
    {
        presenter.ReflectTutrialTelop();

        StartCoroutine(uiManager.TutrialTelop());
    }

}
