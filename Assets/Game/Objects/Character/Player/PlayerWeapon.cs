using UnityEngine;

public class PlayerWeapon : CharacterBase
{
    private CapsuleCollider closeWeaponCollider;    // コリジョンコンポーネント
    public TransformData transformPlayerWeapon;     // プレイヤー武器の情報

    private void Awake()
    {
        // コリジョンコンポーネントを取得
        closeWeaponCollider = GetComponent<CapsuleCollider>();
        closeWeaponCollider.enabled = false; // 初期状態では無効化
    }


    void Update()
    {
        transform.transform.position = transformPlayerWeapon.position;
        transform.rotation           = transformPlayerWeapon.quaternion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 攻撃音を再生する
            Sound.Instance.PlaySE("Slash1");
        }
    }

    /// <summary>
    /// 手動でコリジョンを設定する
    /// </summary>
    public void SetCollision(bool isEnabled)
    {
        if (closeWeaponCollider != null)
        {
            closeWeaponCollider.enabled = isEnabled;
        }
    }
}
