//-------------------------------------------------------------------------
// �L�����N�^�[�̃X�e�[�^�X���Ǘ�����\����
//-------------------------------------------------------------------------
using UnityEngine;
[System.Serializable]
public struct CharacterData
{
    // ========== ��ԃt���O ==========

    [Header("���̏�ŗ�����ԃt���O")]
    public bool standFlag;

    [Header("�ҋ@��ԃt���O")]
    public bool waitFlag;

    [Header("�����ԃt���O")]
    public bool defenseFlag;

    [Header("�ړ���ԃt���O")]
    public bool moveFlag;

    [Header("�m�[�}���U���t���O")]
    public bool normalAttackFlag;

    [Header("���b�N�I���U���t���O")]
    public bool lockOnAttackFlag;

    [Header("�K�E�Z�U���t���O")]
    public bool attackSpecialFlag;

    [Header("�����t���O")]
    public bool survivalFlag;

    [Header("���݃t���O")]
    public bool existFlag;

    [Header("�񕜃t���O")]
    public bool recoveryFlag;

    [Header("�󒆃t���O")]
    public bool airFlag;

    [Header("�n�ʃt���O")]
    public bool earthFlag;

    [Header("�W�����v�t���O")]
    public bool jumpFlag;

    [Header("�ːi�i���b�N�I���j�t���O")]
    public bool lockOnFlag;

    [Header("�����t���O")]
    public bool insideFlag;

    [Header("�Ǐ]�t���O")]
    public bool chaseFlag;

    [Header("�����t���O")]
    public bool winFlag;

    [Header("���b�N�I���`���[�W���t���O")]
    public bool lockOnChargeFlag;

    [Header("���b�N�I���`���[�W�����t���O")]
    public bool lockOnCompFlag;

    [Header("�U�������t���O")]
    public bool attackFlag;

    [Header("�p���B�����t���O")]
    public bool parryFlag;

    [Header("�X�|�[���ς݃t���O")]
    public bool popedFlag;

    [Header("�q�b�g�X�g�b�v���t���O")]
    public bool hitStopFlag;

    [Header("�X�^�~�i�g�p�\�t���O")]
    public bool staminaFlag;

    [Header("�s���\��ԃt���O")]
    public bool stateFlag;

    [Header("��_���[�W���t���O")]
    public bool hitDamageFlag;

    // ========== ���l�p�����[�^ ==========

    [Header("���l�p�����[�^")]

    [Header("�����Ă�������i�p�x�j")]
    public float angle;

    [Header("�ړ����x")]
    public float moveSpeed;

    [Header("�m�b�N�o�b�N��")]
    public float retreatPower;

    [Header("�U���͂̍ő�l")]
    public float attackPowerMax;

    [Header("���݂̍U����")]
    public float attackPower;

    [Header("�̗͂̍ő�l")]
    public float healthMax;

    [Header("���݂̗̑�")]
    public float health;

    [Header("�o���l")]
    public float exp;

    [Header("���b�N�I���J�E���g")]
    public int lockOnCount;             

    [Header("�ړ��J�E���g")]
    public int moveCount;               

    [Header("����p�[�e�B�N���ԍ�")]
    public int weaponParticleNum;       

    [Header("���ł܂ł̃J�E���g")]
    public int deleteCount;             

    [Header("�񕜃J�E���g")]
    public int recoveryCount;           

    [Header("���G����")]
    public int safeCount;               

    [Header("��_���[�W�J�E���g")]
    public int moveStopCount;           

    [Header("�q�b�g�X�g�b�v�J�E���g�i���d�q�b�g�h�~�j")]
    public int hitStopCount;            

    [Header("�q�b�g�X�g�b�v�J�E���g�̍ő�l")]
    public int hitStopCountMax;         

    [Header("�U��������")]
    public int attackNum;               

    [Header("�U���𓖂Ă���")]
    public int beAttackNum;             

    [Header("�^�����_���[�W")]
    public int gaveDamage;              

    [Header("�ǉ��_���[�W")]
    public int damagePlus;              

    [Header("���x���̍ő�l")]
    public int levelMax;                

    [Header("���݂̃��x��")]
    public int level;                                     

    [Header("�X�^�~�i�̍ő�l")]
    public int staminaMax;              

    [Header("���݂̃X�^�~�i")]
    public int stamina;                               
}