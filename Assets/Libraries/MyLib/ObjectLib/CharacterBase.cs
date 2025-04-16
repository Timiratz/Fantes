using UnityEngine;

/// <summary>
/// �L�����N�^�[�̊��N���X
/// </summary>
public abstract class CharacterBase : ObjectBase
{
    // �L�����N�^�[�̃f�[�^�\����
    [SerializeField] private CharacterData m_characterData;

    // �g�����X�t�H�[���̃f�[�^�\����
    [SerializeField] private TransformData m_transformData;

    // �L�����N�^�[�̃f�[�^�̎擾�E�ݒ�
    public CharacterData characterData
    {
        get { return m_characterData; }
        set { m_characterData = value; }
    }

    // �g�����X�t�H�[���̃f�[�^�̎擾�E�ݒ�
    public TransformData transformData
    {
        get { return m_transformData; }
        set { m_transformData = value; }
    }
}
