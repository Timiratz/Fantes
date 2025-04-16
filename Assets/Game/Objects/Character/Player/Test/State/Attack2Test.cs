using UnityEngine;

public class Attack2Test : ITestState
{
    private bool isNextAttack = false; // ���̍U���̗\��
    private bool isButtonReleased = false; // �{�^���������ꂽ���ǂ���

    public void EnterState(TestController player)
    {
        // �U�������Đ�����
        Sound.Instance.PlaySE("NoHitSlash2");
        // �U���A�j���[�V�����̐ݒ�
        player.animator.SetBool("IsFinishAttack", false);
        player.animator.SetBool("IsAttack2", true);
        player.animator.speed = 1.0f;

        // �U�������̐ݒ�
        Vector3 cameraForward = Vector3.Scale(player.GetCameraForward(), new Vector3(1, 0, 1)).normalized;
        player.transformTest.velocity = Vector3.zero;
        player.transformTest.quaternion = Quaternion.LookRotation(cameraForward);

        isButtonReleased = false; // �{�^���������ꂽ��Ԃ����Z�b�g
        isNextAttack     = false; // ���̍U���̗\������Z�b�g
    }

    public void UpdateState(TestController player)
    {
        // �{�^���������ꂽ���ǂ���
        if (InputManager.Instance.IsAttackRelease && !isButtonReleased && !isNextAttack)
            isButtonReleased = true;
        else if (InputManager.Instance.IsAttackPressed && isButtonReleased && !isNextAttack)
            isNextAttack = true;

        // ���݂̃A�j���[�V���������擾
        AnimatorStateInfo currentStateInfo = player.animator.GetCurrentAnimatorStateInfo(0);
        // ���̍U���̗\�񂪂���A�{�^���������ꂽ�ꍇ
        if (isNextAttack)
        {
            NextState(player);
        }
        // �A�j���[�V�����Q�̍Đ����I�������ꍇ
        if (currentStateInfo.IsName("TestAttack2") && currentStateInfo.normalizedTime >= 0.55f)
        {
            NextState(player); // ���̏�ԂɑJ��
        }
    }

    private void NextState(TestController player)
    {
        player.animator.SetBool("IsFinishAttack", true);
        player.animator.SetBool("IsAttack1", false);
        player.animator.SetBool("IsAttack2", false);
        // �X�e�B�b�N���|����Ă���ꍇ
        if (InputManager.Instance.MovementInput.sqrMagnitude > 0.01f)
        {
            // �_�b�V����ԂɑJ��
            player.ChangeState(new DashTest());
        }
        // �X�e�B�b�N���|����Ă��Ȃ��ꍇ
        else
        {
            // �X�^���h��ԂɑJ��
            player.ChangeState(new StandTest());
        }
    }
}
