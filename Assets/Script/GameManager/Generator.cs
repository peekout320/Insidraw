using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class Generator : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private List<Ball> generateBallList = new List<Ball>();
    public List<Ball> GenerateBallList { get => generateBallList; }

    [SerializeField]
    private List<ParticleSystem> particleList = new List<ParticleSystem>();

    private Ball generateBall;

    [SerializeField]
    private Ball ballPrefab;

    [SerializeField]
    private Transform[] ballsTran;

    [SerializeField]
    private BallController ballCon;

    private GameObject UnknownObj;

    [SerializeField]
    private Transform UnknownObjTran;

    private ParticleSystem particle;

    //for文で共有するための数値
    private int listIndex;


    /// <summary>
    /// ボールを３つ生成する
    /// </summary>
    public void GenerateBall()
    {
        for (listIndex = 0; listIndex < 3; listIndex++)
        {
            //ボールを生成しリストに追加
            generateBall = Instantiate(ballPrefab, ballsTran[listIndex], false);

            AddGenerateBalls();

            //ボールの子オブジェクトのパーティクルを取得しSOデータから色を取得し配色する。ついでにリストへ登録。
            particle = generateBall.transform.GetChild(0).GetComponent<ParticleSystem>();
            
            AddParticals();

            SetParticalColor(particleList);
        }

        //ボールに初動を与えるメソッド
        ballCon.MovingBall(generateBallList);

        //接触時のの挙動を与えるメソッド
        ballCon.OnCollision();
    }

    /// <summary>
    /// 生成したボールをリスト化する。
    /// </summary>
    private void AddGenerateBalls()
    {
        generateBallList.Add(generateBall);
    }

    /// <summary>
    /// ボールを破棄しリストもリセットする。
    /// </summary>
    //public void DestroyBalls()
    //{
    //    for (int i = 0; i < generateBallList.Count; i++)
    //        Destroy(generateBallList[i].gameObject);

    //    generateBallList.Clear();
    //}

    /// <summary>
    /// 生成したボールの子オブジェクトのパーティクルをリスト化する
    /// </summary>
    private void AddParticals()
    {
        particleList.Add(particle);
    }

    /// <summary>
    /// ボールを開始位置にリセットし、再配色する。
    /// </summary>
    public void Re_SetupGenerateBalls()
    {
        for (listIndex = 0; listIndex < generateBallList.Count; listIndex++)
        {
            generateBallList[listIndex].transform.position = Vector3.zero;

            SetParticalColor(particleList);
        }
    }

    /// <summary>
    /// Unknownオブジェクトを生成。
    /// </summary>
    /// <param name="gameManager"></param>
    public void GenerateUnknownObject(GameManager gameManager)
    {
        this.gameManager = gameManager;

        UnknownObj = Instantiate(DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].UnknownObj, UnknownObjTran, false);
    }

    /// <summary>
    /// Unknownオブジェクトを破棄。
    /// </summary>
    public void DestroyUnknownObject()
    {
        Destroy(UnknownObj);
    }

    /// <summary>
    /// パーティクルを配色する。
    /// </summary>
    /// <param name="particles"></param>
    private void SetParticalColor(List<ParticleSystem> particles)
    {
        var par = particles[listIndex].trails.colorOverLifetime;

         Debug.Log(par.color + "test1");

        //par.color = DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].color;

         Debug.Log(par.color + "test2");
    }
} 

