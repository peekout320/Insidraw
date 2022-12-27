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
    private List<ParticleSystem.TrailModule> TrailList = new List<ParticleSystem.TrailModule>();

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


    /// <summary>
    /// ボールを３つ生成する
    /// </summary>
    public void GenerateBall()
    {
        for (int i = 0; i < 3; i++)
        {
            //ボールを生成しリストに追加
            generateBall = Instantiate(ballPrefab, ballsTran[i], false);

            AddGenerateBalls();

            //ボールの子オブジェクトのパーティクルを取得しSOデータから色を取得し配色する。ついでにリストへ登録。
            ParticleSystem particle = generateBall.transform.GetChild(0).GetComponent<ParticleSystem>();

            AddParticals(particle);

            ParticleSystem.TrailModule trail = particle.trails;

            AddTrails(trail);

            SetParticalColor(trail);
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
    /// 生成したパーティクルをリスト化する。
    /// </summary>
    /// <param name="particle"></param>
    private void AddParticals(ParticleSystem particle)
    {
        particleList.Add(particle);
    }

    /// <summary>
    /// パーティクルTrailを配色するためのリストを作成
    /// </summary>
    private void AddTrails(ParticleSystem.TrailModule trail)
    {
        TrailList.Add(trail);
    }

    /// <summary>
    /// ボールを開始位置に戻し、再配色する。
    /// </summary>
    public void Re_SetupGenerateBalls()
    {
        for (int i = 0; i < generateBallList.Count; i++)
        {
            generateBallList[i].transform.position = Vector3.zero;

            SetParticalColor(TrailList[i]);
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
    private void SetParticalColor(ParticleSystem.TrailModule particle)
    {
       // Debug.Log(par.color + "test1");

        particle.colorOverLifetime = DataBaseManager.instance.objectDataSO.objrctDataList[gameManager.QuestionNO].color;

        // Debug.Log(par.color + "test2");
    }

    /// <summary>
    /// パーティカルを表示する。
    /// </summary>
    public void OnParticle()
    {
        for(int i = 0; i< particleList.Count;i++)
        {
            particleList[i].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// パーティクルを非表示する。
    /// </summary>
    public void OffParticle()
    {
        for (int i = 0; i < particleList.Count; i++)
        {
            particleList[i].gameObject.SetActive(false);
        }
    }

}

