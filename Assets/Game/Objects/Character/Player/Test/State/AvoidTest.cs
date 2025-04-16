using UnityEngine;

public class AvoidTest : ITestState
{
    private float avoidSpeed;                   // 現在の回避速度
    private float initialAvoidSpeed;            // 回避開始時の速度
    private float targetAvoidSpeed;             // 通常の回避速度
    private float avoidDuration = 0.5f;         // 回避加速が減衰するまでの時間
    private float elapsedTime = 0f;             // 回避開始からの経過時間
    private Vector3 avoidDirection;             // 回避方向

    public void EnterState(TestController player)
    {
        player.animator.SetBool("IsAvoid", true);
        player.animator.speed = 1.1f;
        // カメラ基準の前方方向を取得
        Vector3 cameraForward = Vector3.Scale(player.GetCameraForward(), new Vector3(1, 0, 1)).normalized;
        // 回避方向を後方に設定
        avoidDirection    = -cameraForward;
        // 速度の初期化
        initialAvoidSpeed = player.moveSpeed * 2.5f;
        targetAvoidSpeed  = player.moveSpeed * 0.3f;
        avoidSpeed        = initialAvoidSpeed;
        elapsedTime       = 0f;
        player.transformTest.velocity = Vector3.zero;
        // プレイヤーの向きを回避方向に合わせる
        player.transformTest.quaternion = Quaternion.LookRotation(-avoidDirection);
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // 速度を経過時間に応じて減衰
        avoidSpeed = Mathf.Lerp(
            initialAvoidSpeed,
            targetAvoidSpeed,
            elapsedTime / avoidDuration
        );

        // 回避方向に移動
        player.transformTest.velocity = avoidDirection * avoidSpeed;

        // 回避時間終了後、通常状態に遷移
        if (elapsedTime >= avoidDuration)
        {
            player.ChangeState(new StandTest());
        }
    }
}
