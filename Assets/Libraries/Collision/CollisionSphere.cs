using UnityEngine;

/// <summary>
/// ���̓����蔻��
/// </summary>
[RequireComponent(typeof(Collider))]
public class CollisionSphere : CollisionBase
{
    public override CollisionType GetID() { return CollisionType.Sphere; }  // ����ID
    public float radius = 0.5f;                                             // ���a

    void Reset()
    {
        // �R���C�_�[���A�^�b�`����Ă��Ȃ��ꍇ�̓A�^�b�`����
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider == null)
        {
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        }
        sphereCollider.radius    = radius;  // ���a
        sphereCollider.isTrigger = true;    // �g���K�[�Ƃ��Ĉ���
    }

    /// <summary>
    /// �����蔻��
    /// </summary>
    public override void OnCollision(CollisionBase other)
    {
        // Collision Handling Code
        Debug.Log("Sphere Collision");
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
        return radius; // ���a���擾
    }
    public override void SetRadius(float radius)
    {
        this.radius = radius; // ���a��ݒ�
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            capsuleCollider.radius = radius; // �R���C�_�[�̔��a��ݒ�
        }
    }
}