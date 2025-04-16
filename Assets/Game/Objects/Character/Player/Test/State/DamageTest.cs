using UnityEngine;

public class DamageTest : ITestState
{
    private float elapsedTime = 0f;             // �o�ߎ���

    public void EnterState(TestController player)
    {
        // �A�j���[�V������ݒ肷��
        player.animator.SetBool("IsDefense1", false);
        player.animator.SetBool("IsRuning", false);
        player.animator.SetBool("IsDash", false);
        player.animator.SetBool("IsAvoid", false);
        player.animator.SetBool("IsDamage1", true);
        player.animator.speed = 1.2f;
        // �����Ă͂Ȃ�Ȃ����Ԃ�ݒ肷��
        player.characterTest.moveStopCount = 30;
        // ���G���Ԃ�ݒ肷��
        player.characterTest.safeCount = 60;
        // ���̑��̏���������
        elapsedTime = 0f;
    }

    public void UpdateState(TestController player)
    {
        // �o�ߎ��Ԃ��t���[�����Ƃ��ĉ��Z
        elapsedTime += Time.deltaTime;

        // �U���{�^�����������ꍇ
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new DefenseTest());
            return;
        }

        // �o�ߎ��Ԃ��t���[�����ɕϊ����Ĕ�r
        if ((int)(elapsedTime * 60) >= player.characterTest.moveStopCount)
        {
            elapsedTime = 0; 
            player.ChangeState(new StandTest());
        }
    }

}
