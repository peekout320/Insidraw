using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashTextObj : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private Text txtdisplay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(uiManager.FlashText(10,txtdisplay));
    }
}
