using UnityEngine;

public class JumpTest : ITestState
{
    private float jumpSpeed;                   // ���݂̉�𑬓x
    private float initialJumpSpeed;            // ����J�n���̑��x
    private float targetJumpSpeed;             // �ʏ�̉�𑬓x
    private float jumpDuration = 0.05f;        // �����������������܂ł̎���
    private float elapsedTime  = 0f;           // ����J�n����̌o�ߎ���

    public void EnterState(TestController player)
    {
        player.transformTest.position.y = 0.1f;
        // �󒆃t���O�𗧂Ă�
        player.characterTest.airFlag    = true; 
        // ���x�̏�����
        initialJumpSpeed  = player.moveSpeed * 1.5f;
        targetJumpSpeed   = player.moveSpeed * 0.0f;
        jumpSpeed         = initialJumpSpeed;
        elapsedTime       = 0f;
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // ���x���o�ߎ��Ԃɉ����Č���
        jumpSpeed = Mathf.Lerp(
            initialJumpSpeed,
            targetJumpSpeed,
            elapsedTime / jumpDuration
        );

        // �������Ɉړ�
        player.transformTest.velocity.y += jumpSpeed;

        // ������ԏI����A�ʏ��ԂɑJ��
        if (player.transformTest.position.y <= 0.0f)
        {
            player.ChangeState(new StandTest());
        }
    }
}
