using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private List<Ball> generateBalls = new List<Ball>();
    public List<Ball> GenerateBalls { get => generateBalls; }

    private Ball generateBall;

    [SerializeField]
    private Ball ballPrefab;

    [SerializeField]
    private Transform[] ballsTran;

    [SerializeField]
    private BallController ballCon;

    [SerializeField]
    private Transform UnknownObjTran;

    /// <summary>
    /// ボールを３つ生成する
    /// </summary>
    public void GenerateBall()
    {
        for (int i = 0; i < 3; i++)
        {
            generateBall = Instantiate(ballPrefab, ballsTran[i], false);

            //generateBall.SetupBall();

            AddGenerateBalls();
        }

        //ボールに初動を与えるメソッド
        ballCon.MovingBall(generateBalls);

        //接触時のの挙動を与えるメソッド
        ballCon.OnCollision();
    }

    /// <summary>
    /// 生成したボールをリスト化する
    /// </summary>
    private void AddGenerateBalls()
    {
        generateBalls.Add(generateBall);
    }

    //Unknownオブジェクトを生成
    public void GenerateUnknownObject(GameManager gameManager)
    {
        Instantiate(DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].UnknownObj, UnknownObjTran, false);
    }
 } 

