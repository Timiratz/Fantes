using UnityEngine;

public class PlayerWeapon : CharacterBase
{
    private CapsuleCollider closeWeaponCollider;    // �R���W�����R���|�[�l���g
    public TransformData transformPlayerWeapon;     // �v���C���[����̏��

    private void Awake()
    {
        // �R���W�����R���|�[�l���g���擾
        closeWeaponCollider = GetComponent<CapsuleCollider>();
        closeWeaponCollider.enabled = false; // ������Ԃł͖�����
    }


    void Update()
    {
        transform.transform.position = transformPlayerWeapon.position;
        transform.rotation           = transformPlayerWeapon.quaternion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // �U�������Đ�����
            Sound.Instance.PlaySE("Slash1");
        }
    }

    /// <summary>
    /// �蓮�ŃR���W������ݒ肷��
    /// </summary>
    public void SetCollision(bool isEnabled)
    {
        if (closeWeaponCollider != null)
        {
            closeWeaponCollider.enabled = isEnabled;
        }
    }
}
