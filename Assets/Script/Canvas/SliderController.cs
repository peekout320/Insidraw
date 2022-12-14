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
    private float addPower = 0.5f;

    [SerializeField]
    private BallController ballCon;


    public IEnumerator KeyInputSlider()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            if (!Input.anyKey)
            {
                //Debug.Log("test1");

                ballCon.IsMoving = false;

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
                ballCon.IsMoving = true;

                sliders[0].value -= addPower;
            }

            if (Input.GetKey(KeyCode.T))
            {
                ballCon.IsMoving = true;

                sliders[0].value += addPower;
            }

            //Y軸に対する値を変化させる
            if (Input.GetKey(KeyCode.F))
            {
                ballCon.IsMoving = true;

                sliders[1].value -= addPower;
            }

            if (Input.GetKey(KeyCode.G))
            {
                ballCon.IsMoving = true;

                sliders[1].value += addPower;
            }

            //Z軸に対する値の変化
            if (Input.GetKey(KeyCode.V))
            {
                ballCon.IsMoving = true;

                sliders[2].value -= addPower;
            }

            if (Input.GetKey(KeyCode.B))
            {
                ballCon.IsMoving = true;

                sliders[2].value += addPower;
            }
            yield return null;
        }
    }
}
