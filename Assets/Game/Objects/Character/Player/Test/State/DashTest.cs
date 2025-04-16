using UnityEngine;

/// <summary>
/// プレイヤーがダッシュしている状態
/// </summary>
public class DashTest : ITestState
{
    private float dashSpeed;                // 現在のダッシュ速度
    private float initialDashSpeed;         // ダッシュ開始時の速度
    private float targetDashSpeed;          // 通常のダッシュ速度
    private float dashDuration = 0.5f;      // ダッシュ加速が減衰するまでの時間
    private float elapsedTime = 0f;         // ダッシュ開始からの経過時間

    public void EnterState(TestController player)
    {
        // 回避音を再生
        Sound.Instance.PlaySE("Avoid");

        // スティックが倒されてない場合、回避状態への遷移
        if (InputManager.Instance.MovementInput.sqrMagnitude == 0.00f)
        {
            player.ChangeState(new AvoidTest());
            return;
        }
        player.animator.SetBool("IsDash", true);
        player.animator.speed = 1.3f;
        // ダッシュ速度を初期化
        initialDashSpeed = player.moveSpeed * 4.0f;  // 初速は通常移動速度の4倍
        targetDashSpeed  = player.moveSpeed * 1.5f;  // 通常ダッシュ速度（減衰後）
        dashSpeed        = initialDashSpeed;         // 初期ダッシュ速度を設定
        elapsedTime      = 0f;                       // 経過時間をリセット
    }

    public void UpdateState(TestController player)
    {
        Vector3 moveDirection = Vector3.zero;

        // カメラ基準で前方向と右方向を取得
        Vector3 cameraForward = player.GetCameraForward();
        Vector3 cameraRight = player.GetCameraRight();

        // 移動入力を取得
        Vector2 movementInput = InputManager.Instance.MovementInput;
        moveDirection        += cameraForward * movementInput.y;    // 前後移動
        moveDirection        += cameraRight   * movementInput.x;    // 左右移動

        // 経過時間に応じてダッシュ速度を補間
        elapsedTime += Time.deltaTime;
        dashSpeed = Mathf.Lerp(initialDashSpeed, targetDashSpeed, elapsedTime / dashDuration);

        // 移動入力があれば移動処理
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            // 移動速度を設定
            player.transformTest.velocity = moveDirection.normalized * dashSpeed;
            // 回転処理
            Vector3 flatMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            // 移動方向を基準に回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(flatMoveDirection.normalized);
            // スムーズな補間で回転を更新
            player.transformTest.quaternion = Quaternion.Slerp
            (
                player.transformTest.quaternion, // 現在の回転
                targetRotation,                    // 目標回転
                Time.deltaTime * 10.0f             // 補間速度
            );
        }
        else
        {
            // 移動入力がなくなれば立ち状態に遷移
            player.ChangeState(new StandTest());
            return;
        }

        // ダッシュ開始時の経過時間をリセット
        if (InputManager.Instance.IsDashPressed && elapsedTime >= 1.0f)
        {
            Sound.Instance.PlaySE("Avoid");
            elapsedTime = 0f;
        }
    }
}