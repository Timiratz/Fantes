/// <summary>
/// �L�����N�^�[�̏�Ԃ�\���C���^�[�t�F�[�X
/// </summary>
public interface ITestState
{
    /// <summary>
    /// ��ԊJ�n���̏���
    /// </summary>
    public abstract void EnterState(TestController player);

    /// <summary>
    /// ��ԍX�V����
    /// </summary>
    public abstract void UpdateState(TestController player);
}