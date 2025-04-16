using UnityEngine;

/// <summary>
/// キーボードの入力状態を監視するインターフェース
/// </summary>
public interface IKeyboardObserver
{
    /// <summary>
    /// キーが押されたときの通知
    /// </summary>
    void OnKeyDown(KeyCode key);
    /// <summary>
    /// キーが離されたときの通知
    /// </summary>
    void OnKeyUp(KeyCode key);
}
