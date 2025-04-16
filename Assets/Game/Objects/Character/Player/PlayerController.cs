using UnityEngine;

public class PlayerController : CharacterBase
{
    public enum PlayerState
    {
        Test,  // �f�o�b�O�p�L����
        Yusto  // ���X�g�R�m�c
    }
    private TestController  testController;     // �f�o�b�N�p�L����
    private Yusto           yusto;              // ���X�g�R�m�N���X

    public PlayerState      currentState;        // ���݂̃v���C���[���

    void Start()
    {
        // �f�o�b�N�p�L����
        testController = new TestController();
        testController.StartPlayer(this);
        // ���X�g�R�m�c
        yusto = new Yusto();
        yusto.StartPlayer(this);
    }

    void Update()
    {
        // �J�����̃^�[�Q�b�g��G�ɕύX
        if (InputManager.Instance.IsCameraTarget) LookAtEnemy();

        // ���݂̏�Ԃɉ����ď�����؂�ւ���
        switch (currentState)
        {
            case PlayerState.Test:
                testController.UpdatePlayer(this);
                break;

            case PlayerState.Yusto:
                yusto.UpdatePlayer(this);
                break;
        }
    }

    // �J������őO�����ƉE�������擾����w���p�[���\�b�h
    public Vector3 GetCameraForward()
    {
        return Vector3.Scale(CameraController.Instance.transform.forward, new Vector3(1, 0, 1)).normalized;
    }

    public Vector3 GetCameraRight()
    {
        return Vector3.Scale(CameraController.Instance.transform.right, new Vector3(1, 0, 1)).normalized;
    }

    // �J�������G�Ɍ����悤�ɂ���
    private void LookAtEnemy()
    {
        // Enemy�̃^�O�����I�u�W�F�N�g���擾
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            CameraController.Instance.SetTarget(enemy);
        }
    }
}
