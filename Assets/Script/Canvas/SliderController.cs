using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider[] sliders;
    public Slider[] Sliders { get => sliders; }

    [SerializeField]
    private float addPower = 0.001f;


    public IEnumerator KeyInputSlider()
    {
        while (true)
        {
            if (!Input.anyKey)
            {
                //Debug.Log("test1");

                for (int i = 0; i < sliders.Length; i++)
                {
                    if (sliders[i].value > 0)
                    {
                        sliders[i].value -= addPower;

                        //Debug.Log("test2");
                    }
                    else
                    {
                        sliders[i].value += addPower;

                        //Debug.Log("test3");
                    }
                }
            }
            
            //X軸に対する値を変化させる
            if (Input.GetKey(KeyCode.R))
            {
                sliders[0].value -= addPower;
            }

            if (Input.GetKey(KeyCode.T))
            {
                sliders[0].value += addPower;
            }

            //Y軸に対する値を変化させる
            if (Input.GetKey(KeyCode.F))
            {
                sliders[1].value -= addPower;
            }

            if (Input.GetKey(KeyCode.G))
            {
                sliders[1].value += addPower;
            }

            //Z軸に対する値の変化
            if (Input.GetKey(KeyCode.V))
            {
                sliders[2].value -= addPower;
            }

            if (Input.GetKey(KeyCode.B))
            {
                sliders[2].value += addPower;
            }
            yield return null;
        }
    }
}
