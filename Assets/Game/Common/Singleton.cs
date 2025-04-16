using System;

/// <summary>
/// ��MonoBehaviour�V���O���g���x�[�X�N���X
/// </summary>
public abstract class Singleton<T> where T : class, new()
{
    // �V���O���g���C���X�^���X��ێ�����Lazy<T>�t�B�[���h
    private static readonly Lazy<T> _instance =
        new Lazy<T>(() => new T(), true); // �X���b�h�Z�[�t��Lazy<T>���g�p
    // �X���b�h�Z�[�t�p���b�N�I�u�W�F�N�g
    public static T Instance => _instance.Value;

    // �V���O���g���C���X�^���X���擾����v���p�e�B
    protected Singleton()
    {
        // �V���O���g���̃C���X�^���X�����ɑ��݂���ꍇ�A��O���X���[
        if (_instance.IsValueCreated)
        {
            // �C���X�^���X�����ɑ��݂���ꍇ�A��O���X���[
            throw new InvalidOperationException(
                $"Singleton instance of {typeof(T)} already exists!");
        }
    }
}
