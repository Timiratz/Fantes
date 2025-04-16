using UnityEngine;

/// <summary>
/// �{�b�N�X�̓����蔻��
/// </summary>
[RequireComponent(typeof(Collider))]
public class CollisionBox : CollisionBase
{
    public override CollisionType GetID() { return CollisionType.Box; } // �{�b�N�X��ID

    public Vector3 size = new Vector3(1.0f, 1.0f, 1.0f); // �{�b�N�X�T�C�Y

    void Reset()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }
        boxCollider.size      = size;      // �T�C�Y�ݒ�
        boxCollider.isTrigger = true;      // �g���K�[�Ƃ��Ĉ���
    }

    public override void OnCollision(CollisionBase other)
    {
        // Collision Handling Code
        Debug.Log("Box Collision");
    }
    /// <summary>
    /// ���W���擾���ݒ�    
    /// </summary>
    public override Vector3 GetPosition()
    {
        return transform.position; // �g�����X�t�H�[���̈ʒu���擾
    }
    public override void SetPosition(Vector3 position)
    {
        transform.position = position; // �g�����X�t�H�[���̈ʒu��ݒ�
    }
    /// <summary>
    /// ���a���擾���ݒ�    
    /// </summary>
    public override float GetRadius()
    {
        return 0; // ���a���擾
    }
    public override void SetRadius(float radius)
    {
    }
}
