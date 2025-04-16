using UnityEngine;

public class KingSlimeController : CharacterBase
{
    private IKingSlimeState currentState;               // 現在の状態
    public TransformData transformKingSlime;            // キングスライムの情報
    public CharacterData characterKingSlime;            // キングスライムのデータ
    public Animator      animator;

    [SerializeField] public float moveSpeed = 5.0f;     // キングスライムの移動速度

    void Start()
    {
        characterData                   = characterKingSlime;                     // キングスライムのデータを設定    
        transformKingSlime.position     = transformData.position;                 // 初期座標
        transform.transform.position    = transformKingSlime.position;            // 初期座標
        transform.rotation              = Quaternion.LookRotation(Vector3.right); // 初期回転

        //ChangeState(new StandTest());                                             // 初期状態を設定
    }

    void Update()
    {
        // 現在の状態を更新
        currentState?.UpdateState(this);

        // 内部関数
        ActionRange();  // 行動制限
    }

    /// <summary>
    /// 状態を変更する
    /// </summary>
    public void ChangeState(IKingSlimeState newState)
    {
        currentState = newState;       // 新しい状態に切り替え
        currentState.EnterState(this); // 新しい状態の開始処理を実行
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // 衝突した相手のタグを確認
        if (other.CompareTag("Player"))
        {
        }
        if (other.CompareTag("PlayerWeapon"))
        {
            // 方向ベクトルを反転＆正規化
            Vector3 hitDirection = (transformKingSlime.position - other.transform.position).normalized;
            // ノックバック
            HitMove(hitDirection, 1.0f);
        }
    }

    // ノックバック
    private void HitMove(Vector3 hitDirection, float hitPower)
    {
        // プレイヤーの向きをノックバック方向に合わせる
        transformKingSlime.quaternion = Quaternion.LookRotation(-hitDirection);
        // ノックバック
        transformKingSlime.velocity = hitDirection * hitPower;
    }

    // 行動制限
    private void ActionRange()
    {
        transformKingSlime.velocity.y -= CommonData.Instance.GravityY;
        transformKingSlime.velocity.x *= CommonData.Instance.Friction;
        transformKingSlime.velocity.z *= CommonData.Instance.Friction;

        if (transformKingSlime.position.y <= 0.0f)
        {
            characterKingSlime.airFlag = false;
            transformKingSlime.position.y = 0.0f;
            transformKingSlime.velocity.y = 0.0f;
        }

        characterData = characterKingSlime;                           // キングスライムのデータを設定
        transformKingSlime.position += transformKingSlime.velocity;   // 移動
        transform.transform.position = transformKingSlime.position;   // 座標
        transform.transform.rotation = transformKingSlime.quaternion; // 回転
    }
    }
