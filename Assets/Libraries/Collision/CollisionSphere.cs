using UnityEngine;

/// <summary>
/// 球の当たり判定
/// </summary>
[RequireComponent(typeof(Collider))]
public class CollisionSphere : CollisionBase
{
    public override CollisionType GetID() { return CollisionType.Sphere; }  // 球のID
    public float radius = 0.5f;                                             // 半径

    void Reset()
    {
        // コライダーがアタッチされていない場合はアタッチする
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider == null)
        {
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        }
        sphereCollider.radius    = radius;  // 半径
        sphereCollider.isTrigger = true;    // トリガーとして扱う
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    public override void OnCollision(CollisionBase other)
    {
        // Collision Handling Code
        Debug.Log("Sphere Collision");
    }

    /// <summary>
    /// 座標を取得＆設定    
    /// </summary>
    public override Vector3 GetPosition()
    {
        return transform.position; // トランスフォームの位置を取得
    }
    public override void SetPosition(Vector3 position)
    {
        transform.position = position; // トランスフォームの位置を設定
    }
    /// <summary>
    /// 半径を取得＆設定    
    /// </summary>
    public override float GetRadius()
    {
        return radius; // 半径を取得
    }
    public override void SetRadius(float radius)
    {
        this.radius = radius; // 半径を設定
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            capsuleCollider.radius = radius; // コライダーの半径を設定
        }
    }
}