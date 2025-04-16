using UnityEngine;

public class JumpTest : ITestState
{
    private float jumpSpeed;                   // 現在の回避速度
    private float initialJumpSpeed;            // 回避開始時の速度
    private float targetJumpSpeed;             // 通常の回避速度
    private float jumpDuration = 0.05f;        // 回避加速が減衰するまでの時間
    private float elapsedTime  = 0f;           // 回避開始からの経過時間

    public void EnterState(TestController player)
    {
        player.transformTest.position.y = 0.1f;
        // 空中フラグを立てる
        player.characterTest.airFlag    = true; 
        // 速度の初期化
        initialJumpSpeed  = player.moveSpeed * 1.5f;
        targetJumpSpeed   = player.moveSpeed * 0.0f;
        jumpSpeed         = initialJumpSpeed;
        elapsedTime       = 0f;
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // 速度を経過時間に応じて減衰
        jumpSpeed = Mathf.Lerp(
            initialJumpSpeed,
            targetJumpSpeed,
            elapsedTime / jumpDuration
        );

        // 回避方向に移動
        player.transformTest.velocity.y += jumpSpeed;

        // 回避時間終了後、通常状態に遷移
        if (player.transformTest.position.y <= 0.0f)
        {
            player.ChangeState(new StandTest());
        }
    }
}
