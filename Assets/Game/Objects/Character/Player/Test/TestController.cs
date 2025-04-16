using UnityEngine;

public class TestController : CharacterBase
{
    private ITestState currentState;              // 現在の状態
    public TransformData transformTest;           // プレイヤーの情報
    public CharacterData characterTest;           // プレイヤーのデータ
    public Animator animator;

    private PlayerController playerController;    // プレイヤーコントローラー
    public PlayerWeapon playerWeapon;             // プレイヤーの武器
    public float moveSpeed = 5.0f;                // プレイヤーの移動速度


    public void StartPlayer(PlayerController player)
    {
        playerController             = player;                       // プレイヤーコントローラーを設定
        characterData                = characterTest;                // プレイヤーのデータを設定    
        transformTest.position       = player.transformData.position;// 初期座標
        player.transform.position    = transformTest.position;       // 初期座標
        transformTest.quaternion = Quaternion.LookRotation(Vector3.right); // 初期回転
        ChangeState(new StandTest());                                // 初期状態を設定
        playerWeapon.SetCollision(false);                            // 武器の当たり判定は無効化
    }

    public void UpdatePlayer(PlayerController player)
    {
        // 現在の状態を更新
        currentState?.UpdateState(this);

        // 武器の位置をプレイヤーに合わせる
        player.transformData = transformTest; // プレイヤーの位置を更新
        playerWeapon.transformPlayerWeapon = transformTest;

    }

    // 状態を変更する
    public void ChangeState(ITestState newState)
    {
        currentState = newState;       // 新しい状態に切り替え
        currentState.EnterState(this); // 新しい状態の開始処理を実行
    }

    // 当たり判定処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 方向ベクトルを反転＆正規化
            Vector3 hitDirection = (transformTest.position - other.gameObject.transform.position).normalized;
            // ノックバック
            HitMove(hitDirection, 1.0f);
            ChangeState(new DamageTest());
        }
    }

    // ノックバック
    private void HitMove(Vector3 hitDirection, float hitPower)
    {
        // プレイヤーの向きをノックバック方向に合わせる
        transformTest.quaternion = Quaternion.LookRotation(-hitDirection);
        // ノックバック
        transformTest.velocity = hitDirection * hitPower;
    }
    
    // 武器の当たり判定をオンオフ切り替える
    public void PlayerWeaponCollider(bool isEnabled)
    {
        playerWeapon.SetCollision(isEnabled);
    }

    // カメラ基準で前方向と右方向を取得するヘルパーメソッド
    public Vector3 GetCameraForward()
    {
        return playerController.GetCameraForward();
    }

    public Vector3 GetCameraRight()
    {
        return playerController.GetCameraRight();
    }
}
