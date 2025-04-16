using UnityEngine;

/// <summary>
/// 当たり判定の種類
/// </summary>
public enum CollisionType
{
    Box = 0,
    Sphere,
    Capsule,
    Line,
    Segment,
    Triangle
}

/// <summary>
/// 当たり判定の基底クラス
/// </summary>
public abstract class CollisionBase : MonoBehaviour
{
    /// <summary>
    /// 当たり判定の種類を取得
    /// </summary>
    public abstract CollisionType GetID();

    /// <summary>
    /// 当たり判定の更新
    /// </summary>
    public abstract void OnCollision(CollisionBase other);

    /// <summary>
    /// 座標を取得＆設定    
    /// </summary>
    public abstract Vector3 GetPosition();
    public abstract void SetPosition(Vector3 position);

    /// <summary>
    /// 半径を取得＆設定    
    /// </summary>
    public abstract float GetRadius();
    public abstract void SetRadius(float radius);
}