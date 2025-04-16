using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // �T�E���h�f�[�^���i�[���鎫��
    private Dictionary<string, AudioClip> soundMap = new Dictionary<string, AudioClip>();

    // AudioSource�R���|�[�l���g
    private AudioSource bgmSource;  // BGM�p
    private AudioSource seSource;   // SE�p

    // �{�����[��
    [Range(0f, 1f)] public float bgmVolume = 1f;
    [Range(0f, 1f)] public float seVolume  = 1f;

    private static Sound instance;

    void Awake()
    {
        // �V���O���g���p�^�[��
        if (instance == null)
        {
            instance = this;
            // �V�[���J�ڂ��Ă��j�����Ȃ�
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // AudioSource�R���|�[�l���g��������
        bgmSource = gameObject.AddComponent<AudioSource>();
        seSource = gameObject.AddComponent<AudioSource>();

        // BGM�̓��[�v�Đ���L����
        bgmSource.loop = true;

        // �T�E���h�f�[�^�̓o�^
        RegisterSound("NoHitPrick1", "Sounds/SE/Character/Yusto/noHit_Prick_1");
        RegisterSound("NoHitPrick2", "Sounds/SE/Character/Yusto/noHit_Prick_2");
        RegisterSound("NoHitSlash1", "Sounds/SE/Character/Yusto/noHit_Slash_1");
        RegisterSound("NoHitSlash2", "Sounds/SE/Character/Yusto/noHit_Slash_2");
        RegisterSound("Prick1", "Sounds/SE/Character/Yusto/prick_1");
        RegisterSound("Prick2", "Sounds/SE/Character/Yusto/prick_2");
        RegisterSound("Slash1", "Sounds/SE/Character/Yusto/slash_1");
        RegisterSound("Slash2", "Sounds/SE/Character/Yusto/slash_2");
        RegisterSound("Avoid", "Sounds/SE/Others/avoid_1");
        RegisterSound("Step1", "Sounds/SE/Others/footsteps_1");
        RegisterSound("Step2", "Sounds/SE/Others/footsteps_2");

        // �����{�����[����ݒ�
        SetVolumeBGM(bgmVolume);
        SetVolumeSE(seVolume);
    }

    /// <summary>
    /// �V���O���g���C���X�^���X���擾
    /// </summary>
    public static Sound Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// �T�E���h��o�^����
    /// </summary>
    public void RegisterSound(string name, string path)
    {
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip != null)
        {
            soundMap[name] = clip;
        }
        else
        {
            Debug.LogWarning($"Failed to load sound: {path}");
        }
    }

    /// <summary>
    /// �T�E���h���擾����
    /// </summary>
    public AudioClip GetSound(string name)
    {
        if (soundMap.ContainsKey(name))
            return soundMap[name];

        Debug.LogWarning($"Sound not found: {name}");
        return null;
    }

    /// <summary>
    /// BGM���Đ�����
    /// </summary>
    public void PlayBGM(string name)
    {
        AudioClip clip = GetSound(name);
        if (clip != null && bgmSource.clip != clip) // ����BGM���Đ����łȂ����
        {
            bgmSource.clip = clip;
            bgmSource.volume = bgmVolume;
            bgmSource.Play();
        }
    }

    /// <summary>
    /// SE���Đ�����
    /// </summary>
    public void PlaySE(string name)
    {
        AudioClip clip = GetSound(name);
        if (clip != null)
        {
            seSource.PlayOneShot(clip, seVolume);
        }
    }

    /// <summary>
    /// �����_����SE���Đ�����
    /// </summary>
    public void PlayRandomSE(params string[] names)
    {
        if (names.Length == 0) return;

        string randomName = names[Random.Range(0, names.Length)];
        PlaySE(randomName);
    }

    /// <summary>
    /// BGM���~����
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// SE�̉��ʐݒ�
    /// </summary>
    public void SetVolumeSE(float volume)
    {
        seVolume = Mathf.Clamp01(volume);
        seSource.volume = seVolume; // ���ʂ�AudioSource�ɔ��f
    }

    /// <summary>
    /// BGM�̉��ʐݒ�
    /// </summary>
    public void SetVolumeBGM(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume; // ���ʂ�AudioSource�ɔ��f
    }

    /// <summary>
    /// �S�ẴT�E���h���\�[�X�����
    /// </summary>
    public void ResetSound()
    {
        StopBGM();
        soundMap.Clear();
        // Resources.UnloadUnusedAssets() // ������������i�K�v�ɉ����āj
    }

    void OnDestroy()
    {
        ResetSound();
    }
}
