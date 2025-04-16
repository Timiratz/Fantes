using UnityEngine;

/// <summary>
/// MonoBehaviour���p�������V���O���g���x�[�X�N���X
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;                             // �V���O���g���C���X�^���X
    private static readonly object _lock = new object();    // �X���b�h�Z�[�t�p���b�N�I�u�W�F�N�g
    private static bool _isQuitting = false;                // �A�v���P�[�V�����I���t���O

    // �V���O���g���C���X�^���X���擾����v���p�e�B
    public static T Instance
    {
        get
        {
            // �A�v���P�[�V�������I�����Ă���ꍇ��null��Ԃ�
            if (_isQuitting) return null;
            // �C���X�^���X��null�̏ꍇ�A�X���b�h�Z�[�t�ɃC���X�^���X���擾
            lock (_lock)
            {
                //  �C���X�^���X��null�̏ꍇ�A�V�[��������T��
                if (_instance == null)
                {
                    // �V�[��������C���X�^���X��T��
                    _instance = FindObjectOfType<T>();
                    // �V�[�����ɃC���X�^���X�����݂��Ȃ��ꍇ�A�V����GameObject���쐬
                    if (_instance == null)
                    {
                        // �V����GameObject���쐬���A�V���O���g���C���X�^���X��ǉ�
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = $"{typeof(T).Name} (Singleton)";
                        // �V�[���J�ڎ��ɃI�u�W�F�N�g��j�����Ȃ��悤�ɐݒ�
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        // �V���O���g���̃C���X�^���X�����ɑ��݂���ꍇ�A���݂̃I�u�W�F�N�g��j��
        if (_instance == null)
        {
            _instance = this as T;          // �^�L���X�g
            DontDestroyOnLoad(gameObject);  // �V�[���J�ڎ��ɃI�u�W�F�N�g��j�����Ȃ�
        }
        // �V���O���g���̃C���X�^���X�����݂��A���݂̃I�u�W�F�N�g������łȂ��ꍇ�A���݂̃I�u�W�F�N�g��j��
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // �A�v���P�[�V�����I�����ɃV���O���g���̃C���X�^���X��null�ɐݒ�
    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
