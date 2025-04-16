using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private GameObject player;                    // プレイヤーオブジェクト
    [SerializeField] private float distance = 5.0f;    // プレイヤーとの初期距離
    [SerializeField] private float zoomSpeed = 5.0f;    // ズーム速度
    [SerializeField] private float minDistance = 2.0f;    // 最小距離
    [SerializeField] private float maxDistance = 10.0f;   // 最大距離
    [SerializeField] private float rotationSpeed = 5.0f;    // 回転速度
    [SerializeField] private float interpolationSpeed = 20.0f;   // 補間速度（固定値）

    private Vector3 offset;                                        // プレイヤーとの相対的な位置（オフセット）
    private GameObject enemy;                                      // 相手オブジェクト

    protected override void Awake()
    {
        // 既存のインスタンスがある場合は破棄
        base.Awake();
        // 初期オフセットを計算
        offset = transform.position - player.transform.position;
        // 距離を正規化して初期距離に合わせる
        offset = offset.normalized * distance;
    }

    void Update()
    {
        // ------カメラのズーム処理------ //
        HandleZoom();

        // ------カメラの移動処理------ //
        if (!InputManager.Instance.IsCameraTarget)
        {
            HandleMovement();
        }

        // ------カメラの回転処理------ //
        HandleRotation();
    }

    // カメラのズーム処理
    private void HandleZoom()
    {
        // マウスホイール入力を取得
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // 距離を調整（ズーム速度を掛けて加減算）
        distance -= scroll * zoomSpeed;

        // 距離を最小値・最大値でクランプ（範囲制限）
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // オフセットを更新（現在の距離に基づく）
        offset = offset.normalized * distance;
    }

    // カメラの移動処理
    private void HandleMovement()
    {
        // プレイヤー位置にオフセット分だけ後退した位置にカメラを配置
        Vector3 targetPosition = player.transform.position + offset;


        // カメラ位置をスムーズに補間して移動
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.unscaledDeltaTime);
    }

    // カメラの回転処理
    private void HandleRotation()
    {
        float mx = 0f;
        float my = 0f;
        // コントローラーが接続されている場合
        if (Gamepad.current != null)
        {
            // 右スティックの入力値を取得
            Vector2 rightStickInput = Gamepad.current.rightStick.ReadValue();

            mx += rightStickInput.x * rotationSpeed * 0.1f;  // 横方向（X軸）の回転量
            my += rightStickInput.y * rotationSpeed * 0.1f;  // 縦方向（Y軸）の回転量
        }

        // マウス入力も許可する場合（オプション）
        mx += Input.GetAxis("Mouse X") * rotationSpeed;
        my += Input.GetAxis("Mouse Y") * rotationSpeed;

        // 横回転（Y軸周り）
        if (Mathf.Abs(mx) > 0.01f)
        {
            Quaternion rotationY = Quaternion.AngleAxis(mx, Vector3.up);
            offset = rotationY * offset;
        }

        // 縦回転（X軸周り）
        if (Mathf.Abs(my) > 0.01f)
        {
            Quaternion rotationX = Quaternion.AngleAxis(-my, transform.right);
            Vector3 newOffset = rotationX * offset;

            float angleBetweenUpAndOffset = Vector3.Angle(Vector3.up, newOffset);
            if (angleBetweenUpAndOffset > 10.0f && angleBetweenUpAndOffset < 170.0f)
            {
                offset = newOffset;
            }
        }

        transform.LookAt(player.transform.position);
    }

    // カメラのターゲット処理
    public void SetTarget(GameObject target)
    {
        enemy = target;

        if (enemy != null)
        {
            // プレイヤーの後ろにカメラを配置
            Vector3 playerPosition = player.transform.position;
            Vector3 directionToEnemy = (enemy.transform.position - playerPosition).normalized;

            // プレイヤーの後ろに一定距離でカメラを配置
            Vector3 cameraPosition = playerPosition - directionToEnemy * distance;

            // カメラ位置を設定
            transform.position = cameraPosition;

            // カメラが敵の方向を見るように回転
            transform.LookAt(enemy.transform.position);
        }
    }

}
