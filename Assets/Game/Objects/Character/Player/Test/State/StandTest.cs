public class StandTest : ITestState
{
    public void EnterState(TestController player)
    {
        player.animator.SetBool("IsDefense1", false);
        player.animator.SetBool("IsRuning"  , false);
        player.animator.SetBool("IsDash"    , false);
        player.animator.SetBool("IsAvoid"   , false);
        player.animator.SetBool("IsDamage1" , false);
        player.animator.speed = 1.0f;
    }

    public void UpdateState(TestController player)
    {
        // スティックが少しでも動いている場合
        if (InputManager.Instance.MovementInput.sqrMagnitude > 0.01f) 
        {
            // 移動入力があれば走り状態に遷移
            player.ChangeState(new RunTest());
        }

        // ダッシュ状態に遷移
        if (InputManager.Instance.IsDashPressed)
        {
            player.ChangeState(new DashTest());
        }

        // 攻撃状態に遷移
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new Attack1Test());
        }

        //// 空中にいる場合
        //if (player.characterPlayer.airFlag) return;
        //// ジャンプ状態に遷移
        //if (InputManager.Instance.IsJumpPressed)
        //{
        //    player.ChangeState(new JumpTest());
        //}
    }
}