using UnityEngine;

/// <summary>
/// MonoBehaviourを継承したシングルトンベースクラス
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;                             // シングルトンインスタンス
    private static readonly object _lock = new object();    // スレッドセーフ用ロックオブジェクト
    private static bool _isQuitting = false;                // アプリケーション終了フラグ

    // シングルトンインスタンスを取得するプロパティ
    public static T Instance
    {
        get
        {
            // アプリケーションが終了している場合はnullを返す
            if (_isQuitting) return null;
            // インスタンスがnullの場合、スレッドセーフにインスタンスを取得
            lock (_lock)
            {
                //  インスタンスがnullの場合、シーン内から探す
                if (_instance == null)
                {
                    // シーン内からインスタンスを探す
                    _instance = FindObjectOfType<T>();
                    // シーン内にインスタンスが存在しない場合、新しいGameObjectを作成
                    if (_instance == null)
                    {
                        // 新しいGameObjectを作成し、シングルトンインスタンスを追加
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = $"{typeof(T).Name} (Singleton)";
                        // シーン遷移時にオブジェクトを破棄しないように設定
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        // シングルトンのインスタンスが既に存在する場合、現在のオブジェクトを破棄
        if (_instance == null)
        {
            _instance = this as T;          // 型キャスト
            DontDestroyOnLoad(gameObject);  // シーン遷移時にオブジェクトを破棄しない
        }
        // シングルトンのインスタンスが存在し、現在のオブジェクトがそれでない場合、現在のオブジェクトを破棄
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // アプリケーション終了時にシングルトンのインスタンスをnullに設定
    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }
}
