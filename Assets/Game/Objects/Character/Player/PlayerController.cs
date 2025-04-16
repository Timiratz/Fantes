using UnityEngine;

public class PlayerController : CharacterBase
{
    public enum PlayerState
    {
        Test,  // デバッグ用キャラ
        Yusto  // ユスト騎士団
    }
    private TestController  testController;     // デバック用キャラ
    private Yusto           yusto;              // ユスト騎士クラス

    public PlayerState      currentState;        // 現在のプレイヤー状態

    void Start()
    {
        // デバック用キャラ
        testController = new TestController();
        testController.StartPlayer(this);
        // ユスト騎士団
        yusto = new Yusto();
        yusto.StartPlayer(this);
    }

    void Update()
    {
        // カメラのターゲットを敵に変更
        if (InputManager.Instance.IsCameraTarget) LookAtEnemy();

        // 現在の状態に応じて処理を切り替える
        switch (currentState)
        {
            case PlayerState.Test:
                testController.UpdatePlayer(this);
                break;

            case PlayerState.Yusto:
                yusto.UpdatePlayer(this);
                break;
        }
    }

    // カメラ基準で前方向と右方向を取得するヘルパーメソッド
    public Vector3 GetCameraForward()
    {
        return Vector3.Scale(CameraController.Instance.transform.forward, new Vector3(1, 0, 1)).normalized;
    }

    public Vector3 GetCameraRight()
    {
        return Vector3.Scale(CameraController.Instance.transform.right, new Vector3(1, 0, 1)).normalized;
    }

    // カメラが敵に向くようにする
    private void LookAtEnemy()
    {
        // Enemyのタグを持つオブジェクトを取得
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            CameraController.Instance.SetTarget(enemy);
        }
    }
}
