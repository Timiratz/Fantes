using UnityEngine;

/// <summary>
/// �����蔻��̎��
/// </summary>
public enum CollisionType
{
    Box = 0,
    Sphere,
    Capsule,
    Line,
    Segment,
    Triangle
}

/// <summary>
/// �����蔻��̊��N���X
/// </summary>
public abstract class CollisionBase : MonoBehaviour
{
    /// <summary>
    /// �����蔻��̎�ނ��擾
    /// </summary>
    public abstract CollisionType GetID();

    /// <summary>
    /// �����蔻��̍X�V
    /// </summary>
    public abstract void OnCollision(CollisionBase other);

    /// <summary>
    /// ���W���擾���ݒ�    
    /// </summary>
    public abstract Vector3 GetPosition();
    public abstract void SetPosition(Vector3 position);

    /// <summary>
    /// ���a���擾���ݒ�    
    /// </summary>
    public abstract float GetRadius();
    public abstract void SetRadius(float radius);
}