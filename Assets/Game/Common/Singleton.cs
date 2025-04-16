using System;

/// <summary>
/// 非MonoBehaviourシングルトンベースクラス
/// </summary>
public abstract class Singleton<T> where T : class, new()
{
    // シングルトンインスタンスを保持するLazy<T>フィールド
    private static readonly Lazy<T> _instance =
        new Lazy<T>(() => new T(), true); // スレッドセーフなLazy<T>を使用
    // スレッドセーフ用ロックオブジェクト
    public static T Instance => _instance.Value;

    // シングルトンインスタンスを取得するプロパティ
    protected Singleton()
    {
        // シングルトンのインスタンスが既に存在する場合、例外をスロー
        if (_instance.IsValueCreated)
        {
            // インスタンスが既に存在する場合、例外をスロー
            throw new InvalidOperationException(
                $"Singleton instance of {typeof(T)} already exists!");
        }
    }
}
