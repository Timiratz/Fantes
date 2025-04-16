using UnityEngine;

public class Attack1Test : ITestState
{
    private bool isNextAttack = false; // ���̍U���̗\��
    private bool isButtonReleased = false; // �{�^���������ꂽ���ǂ���

    public void EnterState(TestController player)
    {
        player.PlayerWeaponCollider(true);
        // �U�������Đ�����
        Sound.Instance.PlaySE("NoHitSlash1");
        // �U���A�j���[�V�����̐ݒ�
        player.animator.SetBool("IsFinishAttack", false);
        player.animator.SetBool("IsAttack1", true);
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
        if (InputManager.Instance.IsAttackPressed && isButtonReleased && !isNextAttack)
            isNextAttack = true;

        // ���݂̃A�j���[�V���������擾
        AnimatorStateInfo currentStateInfo = player.animator.GetCurrentAnimatorStateInfo(0);
        // ���̍U���̗\�񂪂���A�{�^���������ꂽ�ꍇ
        if (isNextAttack)
        {
            // ���̍U��
            player.animator.SetBool("IsAttack1", false);
            player.ChangeState(new Attack2Test());
            return;
        }

        // �A�j���[�V�����P�̍Đ����I�������ꍇ
        if (currentStateInfo.IsName("TestAttack1") && currentStateInfo.normalizedTime >= 0.5f)
        {
            NextState(player); // ���̏�ԂɑJ��
        }
    }

    private void NextState(TestController player)
    {
        player.animator.SetBool("IsFinishAttack", true);
        player.animator.SetBool("IsAttack1", false);
        player.animator.SetBool("IsAttack2", false);
        player.PlayerWeaponCollider(false);
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
