using UnityEngine;

public class AvoidTest : ITestState
{
    private float avoidSpeed;                   // ���݂̉�𑬓x
    private float initialAvoidSpeed;            // ����J�n���̑��x
    private float targetAvoidSpeed;             // �ʏ�̉�𑬓x
    private float avoidDuration = 0.5f;         // �����������������܂ł̎���
    private float elapsedTime = 0f;             // ����J�n����̌o�ߎ���
    private Vector3 avoidDirection;             // ������

    public void EnterState(TestController player)
    {
        player.animator.SetBool("IsAvoid", true);
        player.animator.speed = 1.1f;
        // �J������̑O���������擾
        Vector3 cameraForward = Vector3.Scale(player.GetCameraForward(), new Vector3(1, 0, 1)).normalized;
        // ������������ɐݒ�
        avoidDirection    = -cameraForward;
        // ���x�̏�����
        initialAvoidSpeed = player.moveSpeed * 2.5f;
        targetAvoidSpeed  = player.moveSpeed * 0.3f;
        avoidSpeed        = initialAvoidSpeed;
        elapsedTime       = 0f;
        player.transformTest.velocity = Vector3.zero;
        // �v���C���[�̌������������ɍ��킹��
        player.transformTest.quaternion = Quaternion.LookRotation(-avoidDirection);
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // ���x���o�ߎ��Ԃɉ����Č���
        avoidSpeed = Mathf.Lerp(
            initialAvoidSpeed,
            targetAvoidSpeed,
            elapsedTime / avoidDuration
        );

        // �������Ɉړ�
        player.transformTest.velocity = avoidDirection * avoidSpeed;

        // ������ԏI����A�ʏ��ԂɑJ��
        if (elapsedTime >= avoidDuration)
        {
            player.ChangeState(new StandTest());
        }
    }
}
