using UnityEngine;

/// <summary>
/// �v���C���[���_�b�V�����Ă�����
/// </summary>
public class DashTest : ITestState
{
    private float dashSpeed;                // ���݂̃_�b�V�����x
    private float initialDashSpeed;         // �_�b�V���J�n���̑��x
    private float targetDashSpeed;          // �ʏ�̃_�b�V�����x
    private float dashDuration = 0.5f;      // �_�b�V����������������܂ł̎���
    private float elapsedTime = 0f;         // �_�b�V���J�n����̌o�ߎ���

    public void EnterState(TestController player)
    {
        // ��������Đ�
        Sound.Instance.PlaySE("Avoid");

        // �X�e�B�b�N���|����ĂȂ��ꍇ�A�����Ԃւ̑J��
        if (InputManager.Instance.MovementInput.sqrMagnitude == 0.00f)
        {
            player.ChangeState(new AvoidTest());
            return;
        }
        player.animator.SetBool("IsDash", true);
        player.animator.speed = 1.3f;
        // �_�b�V�����x��������
        initialDashSpeed = player.moveSpeed * 4.0f;  // �����͒ʏ�ړ����x��4�{
        targetDashSpeed  = player.moveSpeed * 1.5f;  // �ʏ�_�b�V�����x�i������j
        dashSpeed        = initialDashSpeed;         // �����_�b�V�����x��ݒ�
        elapsedTime      = 0f;                       // �o�ߎ��Ԃ����Z�b�g
    }

    public void UpdateState(TestController player)
    {
        Vector3 moveDirection = Vector3.zero;

        // �J������őO�����ƉE�������擾
        Vector3 cameraForward = player.GetCameraForward();
        Vector3 cameraRight = player.GetCameraRight();

        // �ړ����͂��擾
        Vector2 movementInput = InputManager.Instance.MovementInput;
        moveDirection        += cameraForward * movementInput.y;    // �O��ړ�
        moveDirection        += cameraRight   * movementInput.x;    // ���E�ړ�

        // �o�ߎ��Ԃɉ����ă_�b�V�����x����
        elapsedTime += Time.deltaTime;
        dashSpeed = Mathf.Lerp(initialDashSpeed, targetDashSpeed, elapsedTime / dashDuration);

        // �ړ����͂�����Έړ�����
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            // �ړ����x��ݒ�
            player.transformTest.velocity = moveDirection.normalized * dashSpeed;
            // ��]����
            Vector3 flatMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            // �ړ���������ɉ�]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(flatMoveDirection.normalized);
            // �X���[�Y�ȕ�Ԃŉ�]���X�V
            player.transformTest.quaternion = Quaternion.Slerp
            (
                player.transformTest.quaternion, // ���݂̉�]
                targetRotation,                    // �ڕW��]
                Time.deltaTime * 10.0f             // ��ԑ��x
            );
        }
        else
        {
            // �ړ����͂��Ȃ��Ȃ�Η�����ԂɑJ��
            player.ChangeState(new StandTest());
            return;
        }

        // �_�b�V���J�n���̌o�ߎ��Ԃ����Z�b�g
        if (InputManager.Instance.IsDashPressed && elapsedTime >= 1.0f)
        {
            Sound.Instance.PlaySE("Avoid");
            elapsedTime = 0f;
        }
    }
}