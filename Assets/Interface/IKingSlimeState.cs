/// <summary>
/// �L�����N�^�[�̏�Ԃ�\���C���^�[�t�F�[�X
/// </summary>
public interface IKingSlimeState
{
    /// <summary>
    /// ��ԊJ�n���̏���
    /// </summary>
    public abstract void EnterState(KingSlimeController slime);

    /// <summary>
    /// ��ԍX�V����
    /// </summary>
    public abstract void UpdateState(KingSlimeController slime);
}
