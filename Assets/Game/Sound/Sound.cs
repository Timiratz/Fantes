using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // サウンドデータを格納する辞書
    private Dictionary<string, AudioClip> soundMap = new Dictionary<string, AudioClip>();

    // AudioSourceコンポーネント
    private AudioSource bgmSource;  // BGM用
    private AudioSource seSource;   // SE用

    // ボリューム
    [Range(0f, 1f)] public float bgmVolume = 1f;
    [Range(0f, 1f)] public float seVolume  = 1f;

    private static Sound instance;

    void Awake()
    {
        // シングルトンパターン
        if (instance == null)
        {
            instance = this;
            // シーン遷移しても破棄しない
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // AudioSourceコンポーネントを初期化
        bgmSource = gameObject.AddComponent<AudioSource>();
        seSource = gameObject.AddComponent<AudioSource>();

        // BGMはループ再生を有効化
        bgmSource.loop = true;

        // サウンドデータの登録
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

        // 初期ボリュームを設定
        SetVolumeBGM(bgmVolume);
        SetVolumeSE(seVolume);
    }

    /// <summary>
    /// シングルトンインスタンスを取得
    /// </summary>
    public static Sound Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// サウンドを登録する
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
    /// サウンドを取得する
    /// </summary>
    public AudioClip GetSound(string name)
    {
        if (soundMap.ContainsKey(name))
            return soundMap[name];

        Debug.LogWarning($"Sound not found: {name}");
        return null;
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    public void PlayBGM(string name)
    {
        AudioClip clip = GetSound(name);
        if (clip != null && bgmSource.clip != clip) // 同じBGMが再生中でなければ
        {
            bgmSource.clip = clip;
            bgmSource.volume = bgmVolume;
            bgmSource.Play();
        }
    }

    /// <summary>
    /// SEを再生する
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
    /// ランダムなSEを再生する
    /// </summary>
    public void PlayRandomSE(params string[] names)
    {
        if (names.Length == 0) return;

        string randomName = names[Random.Range(0, names.Length)];
        PlaySE(randomName);
    }

    /// <summary>
    /// BGMを停止する
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// SEの音量設定
    /// </summary>
    public void SetVolumeSE(float volume)
    {
        seVolume = Mathf.Clamp01(volume);
        seSource.volume = seVolume; // 音量をAudioSourceに反映
    }

    /// <summary>
    /// BGMの音量設定
    /// </summary>
    public void SetVolumeBGM(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume; // 音量をAudioSourceに反映
    }

    /// <summary>
    /// 全てのサウンドリソースを解放
    /// </summary>
    public void ResetSound()
    {
        StopBGM();
        soundMap.Clear();
        // Resources.UnloadUnusedAssets() // メモリを解放（必要に応じて）
    }

    void OnDestroy()
    {
        ResetSound();
    }
}
