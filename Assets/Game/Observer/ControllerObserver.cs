using UnityEngine;

/// <summary>
/// コントローラーの入力状態を監視するクラス
/// </summary>
public class ControllerObserver : MonoBehaviour, IControllerObserver
{
    /// <summary>
    /// コントローラー接続時の通知
    /// </summary>
    public void OnControllerConnected(string controllerName)
    {
        //Debug.Log($"コントローラーが接続されました : {controllerName}");
    }

    /// <summary>
    /// コントローラー切断時の通知
    /// </summary>
    public void OnControllerDisconnected(string controllerName)
    {
        //Debug.Log($"コントローラーが切断されました : {controllerName}");
    }

    /// <summary>
    /// 各ボタン押下時の通知
    /// </summary>
    public void OnButtonDown(string controllerName, string buttonName)
    {
        //Debug.Log($"ボタン押下 : {controllerName} - {buttonName}");
    }

    /// <summary>
    /// 各ボタン離上時の通知
    /// </summary>
    public void OnButtonUp(string controllerName, string buttonName)
    {
        //Debug.Log($"ボタン離上 : {controllerName} - {buttonName}");
    }

    /// <summary>
    /// 左右アナログスティックの移動の通知
    /// </summary>
    public void StickMove(string controllerName, string axisName, Vector2 value)
    {
        //Debug.Log($"スティック移動 : {controllerName} - {axisName} - {value}");
    }

    /// <summary>
    /// 左右アナログスティック押下時の通知
    /// </summary>
    public void OnStickDown(string controllerName, string axisName)
    {
        //Debug.Log($"スティック押下 : {controllerName} - {axisName}");
    }

    /// <summary>
    /// 左右アナログスティック離上時の通知
    /// </summary>
    public void OnStickUp(string controllerName, string axisName)
    {
        //Debug.Log($"スティック離上 : {controllerName} - {axisName}");
    }

    /// <summary>
    /// トリガー押下時の通知
    /// </summary>
    public void OnTriggerDown(string controllerName, string triggerName)
    {
        //Debug.Log($"トリガー押下 : {controllerName} - {triggerName}");
    }

    /// <summary>
    /// トリガー離上時の通知
    /// </summary>
    public void OnTriggerUp(string controllerName, string triggerName)
    {
        //Debug.Log($"トリガー離上 : {controllerName} - {triggerName}");
    }
}