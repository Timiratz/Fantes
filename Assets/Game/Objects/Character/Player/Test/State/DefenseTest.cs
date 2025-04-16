using UnityEngine;

public class DefenseTest : ITestState
{
    private float elapsedTime = 0f;             // �o�ߎ���

    public void EnterState(TestController player)
    {
        // �A�j���[�V������ݒ肷��
        player.animator.SetBool("IsDamage1", false);
        player.animator.SetBool("IsDefense1", true);
        player.animator.speed = 1.0f;
        // ���Ԃ�ݒ肷��
        elapsedTime = 0f;
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // ���݂̃A�j���[�V���������擾
        AnimatorStateInfo currentStateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        // �A�j���[�V�������I�������ꍇ
        if (currentStateInfo.IsName("TestDefense1") && currentStateInfo.normalizedTime >= 0.3f)
        {
            // ���̏�ԂɑJ��
            player.animator.SetBool("IsDefense1", false);
            player.ChangeState(new StandTest());
        }
    }
}
