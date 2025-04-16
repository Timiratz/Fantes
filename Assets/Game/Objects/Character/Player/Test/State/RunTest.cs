using UnityEngine;

public class RunTest : ITestState
{
    public void EnterState(TestController player)
    {
        player.animator.SetBool("IsRuning", true);
        player.animator.speed = 1.0f;
    }

    public void UpdateState(TestController player)
    {
        Vector3 moveDirection = Vector3.zero;

        // カメラ基準で前方向と右方向を取得
        Vector3 cameraForward = player.GetCameraForward();
        Vector3 cameraRight   = player.GetCameraRight();

        // 移動入力を取得
        Vector2 movementInput = InputManager.Instance.MovementInput;
        moveDirection += cameraForward * movementInput.y;    // 前後移動
        moveDirection += cameraRight * movementInput.x;    // 左右移動

        // 移動入力があれば移動処理
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            // 移動速度をスティックの傾き具合に比例させる
            float inputMagnitude = movementInput.magnitude;
            player.transformTest.velocity = moveDirection.normalized * player.moveSpeed * inputMagnitude;

            // 回転処理（移動方向に向けて回転）
            Vector3 flatMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            // 移動方向を基準に回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(flatMoveDirection.normalized);
            // スムーズに回転
            player.transformTest.quaternion = Quaternion.Slerp
            (
                player.transformTest.quaternion,  // 現在の回転
                targetRotation,                     // 目標回転
                Time.deltaTime * 10.0f              // 補間速度
            );

            // アニメーション速度を移動入力の強さに比例させる
            player.animator.speed = Mathf.Clamp(inputMagnitude, 0.3f, 1.0f);
        }
        else
        {
            // 移動入力がなくなれば立ち状態に遷移
            player.ChangeState(new StandTest());
        }

        // ダッシュ状態への遷移
        if (InputManager.Instance.IsDashPressed)
        {
            player.ChangeState(new DashTest());
        }

        // 攻撃状態に遷移
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new Attack1Test());
        }
    }
}
