using UnityEngine;

public class RunTest : ITestState
{
    public void EnterState(TestController player)
    {
        player.animator.SetBool("IsRuning", true);
        player.animator.speed = 1.0f;
    }

    public void UpdateState(TestController player)
    {
        Vector3 moveDirection = Vector3.zero;

        // �J������őO�����ƉE�������擾
        Vector3 cameraForward = player.GetCameraForward();
        Vector3 cameraRight   = player.GetCameraRight();

        // �ړ����͂��擾
        Vector2 movementInput = InputManager.Instance.MovementInput;
        moveDirection += cameraForward * movementInput.y;    // �O��ړ�
        moveDirection += cameraRight * movementInput.x;    // ���E�ړ�

        // �ړ����͂�����Έړ�����
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            // �ړ����x���X�e�B�b�N�̌X����ɔ�Ⴓ����
            float inputMagnitude = movementInput.magnitude;
            player.transformTest.velocity = moveDirection.normalized * player.moveSpeed * inputMagnitude;

            // ��]�����i�ړ������Ɍ����ĉ�]�j
            Vector3 flatMoveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
            // �ړ���������ɉ�]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(flatMoveDirection.normalized);
            // �X���[�Y�ɉ�]
            player.transformTest.quaternion = Quaternion.Slerp
            (
                player.transformTest.quaternion,  // ���݂̉�]
                targetRotation,                     // �ڕW��]
                Time.deltaTime * 10.0f              // ��ԑ��x
            );

            // �A�j���[�V�������x���ړ����͂̋����ɔ�Ⴓ����
            player.animator.speed = Mathf.Clamp(inputMagnitude, 0.3f, 1.0f);
        }
        else
        {
            // �ړ����͂��Ȃ��Ȃ�Η�����ԂɑJ��
            player.ChangeState(new StandTest());
        }

        // �_�b�V����Ԃւ̑J��
        if (InputManager.Instance.IsDashPressed)
        {
            player.ChangeState(new DashTest());
        }

        // �U����ԂɑJ��
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new Attack1Test());
        }
    }
}
