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
        // �X�e�B�b�N�������ł������Ă���ꍇ
        if (InputManager.Instance.MovementInput.sqrMagnitude > 0.01f) 
        {
            // �ړ����͂�����Α����ԂɑJ��
            player.ChangeState(new RunTest());
        }

        // �_�b�V����ԂɑJ��
        if (InputManager.Instance.IsDashPressed)
        {
            player.ChangeState(new DashTest());
        }

        // �U����ԂɑJ��
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new Attack1Test());
        }

        //// �󒆂ɂ���ꍇ
        //if (player.characterPlayer.airFlag) return;
        //// �W�����v��ԂɑJ��
        //if (InputManager.Instance.IsJumpPressed)
        //{
        //    player.ChangeState(new JumpTest());
        //}
    }
}