using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private Generator generator;

    [SerializeField]
    private SliderController sliderCon;

    [SerializeField]
    private View view;

    [SerializeField]
    private int questionNo;
    public int QuestionNO { get => questionNo; }

    private void Start()
    {
        //ボール生成
        generator.GenerateBall();

        //問題となるオブジェクトの生成
        generator.GenerateUnknownObject(this);

        //キー入力をスライダーに反映
        StartCoroutine(sliderCon.KeyInputSlider());
    }

    public void JudgeString()
    {
        if (view.InputForm.text == DataBaseManager.instance.objectDataSO.objrctDataList[questionNo].name)
        {
            Debug.Log("正解");

            questionNo++;

            //TODO 正解のSE
            //TODO 数秒おいて次のオブジェクトに切り替える
        }
        else
        {
            Debug.Log("不正解");

            //TODO 不正解SE
        }
    }

}
