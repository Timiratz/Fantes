using UnityEngine;

public class KingSlimeController : CharacterBase
{
    private IKingSlimeState currentState;               // ���݂̏��
    public TransformData transformKingSlime;            // �L���O�X���C���̏��
    public CharacterData characterKingSlime;            // �L���O�X���C���̃f�[�^
    public Animator      animator;

    [SerializeField] public float moveSpeed = 5.0f;     // �L���O�X���C���̈ړ����x

    void Start()
    {
        characterData                   = characterKingSlime;                     // �L���O�X���C���̃f�[�^��ݒ�    
        transformKingSlime.position     = transformData.position;                 // �������W
        transform.transform.position    = transformKingSlime.position;            // �������W
        transform.rotation              = Quaternion.LookRotation(Vector3.right); // ������]

        //ChangeState(new StandTest());                                             // ������Ԃ�ݒ�
    }

    void Update()
    {
        // ���݂̏�Ԃ��X�V
        currentState?.UpdateState(this);

        // �����֐�
        ActionRange();  // �s������
    }

    /// <summary>
    /// ��Ԃ�ύX����
    /// </summary>
    public void ChangeState(IKingSlimeState newState)
    {
        currentState = newState;       // �V������Ԃɐ؂�ւ�
        currentState.EnterState(this); // �V������Ԃ̊J�n���������s
    }

    /// <summary>
    /// �����蔻�菈��
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // �Փ˂�������̃^�O���m�F
        if (other.CompareTag("Player"))
        {
        }
        if (other.CompareTag("PlayerWeapon"))
        {
            // �����x�N�g���𔽓]�����K��
            Vector3 hitDirection = (transformKingSlime.position - other.transform.position).normalized;
            // �m�b�N�o�b�N
            HitMove(hitDirection, 1.0f);
        }
    }

    // �m�b�N�o�b�N
    private void HitMove(Vector3 hitDirection, float hitPower)
    {
        // �v���C���[�̌������m�b�N�o�b�N�����ɍ��킹��
        transformKingSlime.quaternion = Quaternion.LookRotation(-hitDirection);
        // �m�b�N�o�b�N
        transformKingSlime.velocity = hitDirection * hitPower;
    }

    // �s������
    private void ActionRange()
    {
        transformKingSlime.velocity.y -= CommonData.Instance.GravityY;
        transformKingSlime.velocity.x *= CommonData.Instance.Friction;
        transformKingSlime.velocity.z *= CommonData.Instance.Friction;

        if (transformKingSlime.position.y <= 0.0f)
        {
            characterKingSlime.airFlag = false;
            transformKingSlime.position.y = 0.0f;
            transformKingSlime.velocity.y = 0.0f;
        }

        characterData = characterKingSlime;                           // �L���O�X���C���̃f�[�^��ݒ�
        transformKingSlime.position += transformKingSlime.velocity;   // �ړ�
        transform.transform.position = transformKingSlime.position;   // ���W
        transform.transform.rotation = transformKingSlime.quaternion; // ��]
    }
    }
