using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ユーティリティ関数を提供する静的クラス
/// </summary>
public static class Utility
{
    // ========== 定数 ==========
    public const float PI = 3.141593f; // 円周率

    // ========== 関数系 ==========

    /// <summary>
    /// 安全なメモリ解放（Unityでは不要なので代替処理）
    /// </summary>
    public static void SafeDestroy(GameObject obj)
    {
        if (obj != null)
        {
            GameObject.Destroy(obj);
            obj = null;
        }
    }

    /// <summary>
    /// ランダム値を生成する
    /// </summary>
    public static float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    /// <summary>
    /// 度数からラジアンへの変換
    /// </summary>
    public static float DegreeToRadian(float angle)
    {
        return angle * PI / 180f;
    }

    /// <summary>
    /// ラジアンから度数への変換
    /// </summary>
    public static float RadianToDegree(float radian)
    {
        return radian * 180f / PI;
    }

    /// <summary>
    /// ある座標からターゲット座標への正規化ベクトルを返す
    /// </summary>
    public static Vector3 PosToTargetNormalizeVec(Vector3 pos, Vector3 targetPos)
    {
        return (targetPos - pos).normalized;
    }

    /// <summary>
    /// ある座標とある座標の中間点を求める
    /// </summary>
    public static Vector3 Pos1ToPos2DistanceCenter(Vector3 pos1, Vector3 pos2)
    {
        return (pos1 + pos2) / 2f;
    }

    /// <summary>
    /// ある座標とある座標の距離を求める
    /// </summary>
    public static float Distance(Vector3 pos1, Vector3 pos2)
    {
        return Vector3.Distance(pos1, pos2);
    }

    /// <summary>
    /// クランプ関数（値を範囲内に制限）
    /// </summary>
    public static float Clamp(float value, float min, float max)
    {
        return Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// 線形補間（Lerp）
    /// </summary>
    public static float Lerp(float t, float start, float end)
    {
        return Mathf.Lerp(start, end, t);
    }

    /// <summary>
    /// 小数点以下指定桁で切り捨てる
    /// </summary>
    public static float Truncate(float num, int prec)
    {
        float scale = Mathf.Pow(10f, prec);
        return Mathf.Floor(num * scale) / scale;
    }

    /// <summary>
    /// 半径内にターゲットが存在するか確認する
    /// </summary>
    public static bool FindRadius(Vector3 you, Vector3 target, float radius)
    {
        return (target - you).sqrMagnitude <= radius * radius;
    }

    /// <summary>
    /// ２つの位置ベクトル間の角度を計算する関数
    /// </summary>
    public static float CalculationAngle(Vector3 you, Vector3 target)
    {
        // ターゲット方向ベクトル取得
        Vector3 forward = (target - you).normalized;
        // 内積から角度取得
        float angle = Mathf.Acos(Vector3.Dot(forward, Vector3.forward));
        // 外積計算で符号決定
        Vector3 crossProduct = Vector3.Cross(forward, Vector3.forward);
        // 外積が下向きならマイナスにする
        if (crossProduct.y < 0) angle = -angle;
        // ラジアンから度数に変換して返す
        return angle * Mathf.Rad2Deg;
    }

    /// <summary>
    /// シグモイド関数を処理する
    /// </summary>
    public static float Sigmoid(float x)
    {
        return 1.0f / (1.0f + Mathf.Exp(-x));
    }

    /// <summary>
    /// ソフトマックス関数を処理する
    /// </summary>
    public static List<float> Softmax(List<float> x)
    {
        // 結果を格納するリスト
        List<float> result = new List<float>();
        // 指数関数の和を計算
        float sumExp = 0.0f;
        // 指数関数の和を計算
        foreach (float value in x)
            sumExp += Mathf.Exp(value);
        // ソフトマックス関数を計算
        foreach (float value in x)
            result.Add(Mathf.Exp(value) / sumExp);

        return result;
    }
}
