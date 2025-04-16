using UnityEngine;

public class TestController : CharacterBase
{
    private ITestState currentState;              // ���݂̏��
    public TransformData transformTest;           // �v���C���[�̏��
    public CharacterData characterTest;           // �v���C���[�̃f�[�^
    public Animator animator;

    private PlayerController playerController;    // �v���C���[�R���g���[���[
    public PlayerWeapon playerWeapon;             // �v���C���[�̕���
    public float moveSpeed = 5.0f;                // �v���C���[�̈ړ����x


    public void StartPlayer(PlayerController player)
    {
        playerController             = player;                       // �v���C���[�R���g���[���[��ݒ�
        characterData                = characterTest;                // �v���C���[�̃f�[�^��ݒ�    
        transformTest.position       = player.transformData.position;// �������W
        player.transform.position    = transformTest.position;       // �������W
        transformTest.quaternion = Quaternion.LookRotation(Vector3.right); // ������]
        ChangeState(new StandTest());                                // ������Ԃ�ݒ�
        playerWeapon.SetCollision(false);                            // ����̓����蔻��͖�����
    }

    public void UpdatePlayer(PlayerController player)
    {
        // ���݂̏�Ԃ��X�V
        currentState?.UpdateState(this);

        // ����̈ʒu���v���C���[�ɍ��킹��
        player.transformData = transformTest; // �v���C���[�̈ʒu���X�V
        playerWeapon.transformPlayerWeapon = transformTest;

    }

    // ��Ԃ�ύX����
    public void ChangeState(ITestState newState)
    {
        currentState = newState;       // �V������Ԃɐ؂�ւ�
        currentState.EnterState(this); // �V������Ԃ̊J�n���������s
    }

    // �����蔻�菈��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // �����x�N�g���𔽓]�����K��
            Vector3 hitDirection = (transformTest.position - other.gameObject.transform.position).normalized;
            // �m�b�N�o�b�N
            HitMove(hitDirection, 1.0f);
            ChangeState(new DamageTest());
        }
    }

    // �m�b�N�o�b�N
    private void HitMove(Vector3 hitDirection, float hitPower)
    {
        // �v���C���[�̌������m�b�N�o�b�N�����ɍ��킹��
        transformTest.quaternion = Quaternion.LookRotation(-hitDirection);
        // �m�b�N�o�b�N
        transformTest.velocity = hitDirection * hitPower;
    }
    
    // ����̓����蔻����I���I�t�؂�ւ���
    public void PlayerWeaponCollider(bool isEnabled)
    {
        playerWeapon.SetCollision(isEnabled);
    }

    // �J������őO�����ƉE�������擾����w���p�[���\�b�h
    public Vector3 GetCameraForward()
    {
        return playerController.GetCameraForward();
    }

    public Vector3 GetCameraRight()
    {
        return playerController.GetCameraRight();
    }
}
