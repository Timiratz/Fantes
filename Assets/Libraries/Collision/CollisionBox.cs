using UnityEngine;

/// <summary>
/// ボックスの当たり判定
/// </summary>
[RequireComponent(typeof(Collider))]
public class CollisionBox : CollisionBase
{
    public override CollisionType GetID() { return CollisionType.Box; } // ボックスのID

    public Vector3 size = new Vector3(1.0f, 1.0f, 1.0f); // ボックスサイズ

    void Reset()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }
        boxCollider.size      = size;      // サイズ設定
        boxCollider.isTrigger = true;      // トリガーとして扱う
    }

    public override void OnCollision(CollisionBase other)
    {
        // Collision Handling Code
        Debug.Log("Box Collision");
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
        return 0; // 半径を取得
    }
    public override void SetRadius(float radius)
    {
    }
}
