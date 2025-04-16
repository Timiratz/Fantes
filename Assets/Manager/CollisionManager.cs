using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // �Փˎ��̒ʒm�C�x���g
    public delegate void CollisionEvent(GameObject other);
    public static event CollisionEvent OnPlayerCollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂�������̃Q�[���I�u�W�F�N�g���擾
        GameObject otherObject = collision.collider.gameObject;

        // �v���C���[�������ƏՓ˂����ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"�v���C���[�� {otherObject.name} �ƏՓ˂��܂���");
            Notify(otherObject);
        }
        else if (otherObject.CompareTag("Player"))
        {
            Debug.Log($"�v���C���[�� {collision.gameObject.name} �ƏՓ˂��܂���");
            Notify(collision.gameObject);
        }
    }

    private void Notify(GameObject other)
    {
        Debug.Log($"Notify: �v���C���[�� {other.name} �ƏՓ˂��܂���"); // �f�o�b�O���O
        OnPlayerCollisionDetected?.Invoke(other);                       // �C�x���g����
    }
}
