using UnityEngine;

/// <summary>
/// コントローラーの入力状態を監視するインターフェース
/// </summary>
public interface IControllerObserver
{
    /// <summary>
    /// コントローラー接続時の通知
    /// </summary>
    void OnControllerConnected(string controllerName);

    /// <summary>
    /// コントローラー切断時の通知
    /// </summary>
    void OnControllerDisconnected(string controllerName);

    /// <summary>
    /// 各ボタン押下時の通知
    /// </summary>
    void OnButtonDown(string controllerName, string buttonName);

    /// <summary>
    /// 各ボタン離上時の通知
    /// </summary>
    void OnButtonUp(string controllerName, string buttonName);

    /// <summary>
    /// 左右アナログスティックの移動の通知
    /// </summary>
    void StickMove(string controllerName, string axisName, Vector2 value);

    /// <summary>
    /// 左右アナログスティック押下時の通知
    /// </summary>
    void OnStickDown(string controllerName, string axisName);

    /// <summary>
    /// 左右アナログスティック離上時の通知
    /// </summary>
    void OnStickUp(string controllerName, string axisName);

    /// <summary>
    /// トリガー押下時の通知
    /// </summary>
    void OnTriggerDown(string controllerName, string triggerName);

    /// <summary>
    /// トリガー離上時の通知
    /// </summary>
    void OnTriggerUp(string controllerName, string triggerName);
}