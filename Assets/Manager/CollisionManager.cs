using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // 衝突時の通知イベント
    public delegate void CollisionEvent(GameObject other);
    public static event CollisionEvent OnPlayerCollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手のゲームオブジェクトを取得
        GameObject otherObject = collision.collider.gameObject;

        // プレイヤーが何かと衝突した場合
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"プレイヤーが {otherObject.name} と衝突しました");
            Notify(otherObject);
        }
        else if (otherObject.CompareTag("Player"))
        {
            Debug.Log($"プレイヤーが {collision.gameObject.name} と衝突しました");
            Notify(collision.gameObject);
        }
    }

    private void Notify(GameObject other)
    {
        Debug.Log($"Notify: プレイヤーが {other.name} と衝突しました"); // デバッグログ
        OnPlayerCollisionDetected?.Invoke(other);                       // イベント発火
    }
}
