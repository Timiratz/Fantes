using UnityEngine;


// トランスフォームデータ
[System.Serializable]
public struct TransformData
{
    public Vector3 position;      // 座標
    public Vector3 velocity;      // 速度
    public Vector3 target;        // ターゲット
    public Quaternion quaternion; // クォーターニオン
}
