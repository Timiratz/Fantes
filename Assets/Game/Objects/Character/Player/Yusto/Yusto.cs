using UnityEngine;

public class Yusto : CharacterBase
{
    private IYustoState   currentState;              // ���݂̏��
    public  Animator      animatorYusto;             // ���X�g�R�m�A�j���[�^�[

    [SerializeField] public float moveSpeed = 5.0f;  // �v���C���[�̈ړ����x

    public void StartPlayer(PlayerController player)
    {
        
    }

    public void UpdatePlayer(PlayerController player)
    {
        // ���݂̏�Ԃ��X�V
        currentState?.UpdateState(this);

    }

    // ��Ԃ�ύX����
    public void ChangeState(IYustoState newState)
    {
        currentState = newState;       // �V������Ԃɐ؂�ւ�
        currentState.EnterState(this); // �V������Ԃ̊J�n���������s
    }
}
