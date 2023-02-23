using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 定数クラス
/// </summary>
public static class TIME_DATA
{
    /// <summary>
    /// TimeUpを表示する時間
    /// </summary>
    public const float TIME_UP_DISPLAY_TIME = 5.5f;

    /// <summary>
    /// 答えを表示する時間
    /// </summary>
    public const int ANSWER_DISPLAY_TIME = 6;

    /// <summary>
    /// [GameOver]を画面に表示する時間
    /// </summary>
    public const int GAME_OVER_DISPLAY = 7;

    /// <summary>
    /// ゲームオーバー時からそコアを中央に表示するまでの時間
    /// </summary>
    public const int SCORE_DISPLAY_TIME = 3;

    /// <summary>
    /// ゲームオーバー⇨スコアを中央に表示してからタイトルシーンに遷移するまでの時間
    /// </summary>
    public const int TITLESCENE_TRANSITION_TIME = 5;

    /// <summary>
    /// フェードイン/アウトにかかる時間
    /// </summary>
    public const int FADE_TIME = 3;

    /// <summary>
    /// チュートリアルでテロップを切り替える間隔の秒数
    /// </summary>
    public const float TELOP_SPEED = 8;

    /// <summary>
    /// 次の問題の準備での待機時間
    /// </summary>
    public const float NEXT_QUESTION_PREPARATE_TIME = 0.5f;

    /// <summary>
    /// スコアに加算、減算するポイントの表示時間
    /// </summary>
    public const float SUM_SCORE_DISPLAY_TIME = 5;

    /// <summary>
    /// １つ目のボールを光らせた後に２つ目のボールを光らせるまでの待機時間
    /// </summary>
    public const float BALL_LIGHT_UP_TIME1 = 0.85f;

    /// <summary>
    /// 2つ目のボールを光らせた後に3つ目のボールを光らせるまでの待機時間
    /// </summary>
    public const float BALL_LIGHT_UP_TIME2 = 1.1f;

    /// <summary>
    /// シーン遷移のボタンを押下時の待機時間
    /// </summary>
    public const float CHANGESCENE_TRANSITION_TIME1 = 2;

    /// <summary>
    /// シーン遷移時のフェードインの待機時間
    /// </summary>
    public const float CHANGESCENE_TRANSITION_TIME2 = 4;
}