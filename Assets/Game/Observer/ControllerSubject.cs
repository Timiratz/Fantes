using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

/// <summary>
/// コントローラーの接続状態を監視し、入力状態を通知するクラス
/// </summary>
public class ControllerSubject : MonoBehaviour
{
    // オブザーバーリスト
    private List<IControllerObserver> observers = new List<IControllerObserver>();

    /// <summary>
    /// オブザーバーを登録
    /// </summary>
    /// <param name="observer">登録するオブザーバー</param>
    public void RegisterObserver(IControllerObserver observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// オブザーバーを解除
    /// </summary>
    /// <param name="observer">解除するオブザーバー</param>
    public void UnregisterObserver(IControllerObserver observer)
    {
        observers.Remove(observer);
    }

    private void OnEnable()
    {
        // InputSystemのデバイス変更イベントに登録
        InputSystem.onDeviceChange += HandleDeviceChange;
    }

    private void OnDisable()
    {
        // InputSystemのデバイス変更イベントから解除
        InputSystem.onDeviceChange -= HandleDeviceChange;
    }

    /// <summary>
    /// デバイス接続状態の変更を通知
    /// </summary>
    /// <param name="device">変更されたデバイス</param>
    /// <param name="change">変更の種類</param>
    private void HandleDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Added:
                // デバイスが接続された場合
                NotifyControllerConnected(device.displayName);
                break;
            case InputDeviceChange.Removed:
                // デバイスが切断された場合
                NotifyControllerDisconnected(device.displayName);
                break;
        }
    }

    /// <summary>
    /// コントローラー接続時に通知
    /// </summary>
    /// <param name="controllerName">接続されたコントローラーの名前</param>
    public void NotifyControllerConnected(string controllerName)
    {
        foreach (var observer in observers)
        {
            observer.OnControllerConnected(controllerName);
        }
    }

    /// <summary>
    /// コントローラー切断時に通知
    /// </summary>
    /// <param name="controllerName">切断されたコントローラーの名前</param>
    public void NotifyControllerDisconnected(string controllerName)
    {
        foreach (var observer in observers)
        {
            observer.OnControllerDisconnected(controllerName);
        }
    }

    /// <summary>
    /// 各ボタン押下時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="buttonName">押されたボタンの名前</param>
    public void NotifyButtonDown(string controllerName, string buttonName)
    {
        foreach (var observer in observers)
        {
            observer.OnButtonDown(controllerName, buttonName);
        }
    }

    /// <summary>
    /// 各ボタン離上時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="buttonName">離されたボタンの名前</param>
    public void NotifyButtonUp(string controllerName, string buttonName)
    {
        foreach (var observer in observers)
        {
            observer.OnButtonUp(controllerName, buttonName);
        }
    }

    /// <summary>
    /// 左右アナログスティックの移動の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="axisName">移動した軸の名前</param>
    /// <param name="value">移動量</param>
    public void NotifyStickMove(string controllerName, string axisName, Vector2 value)
    {
        foreach (var observer in observers)
        {
            observer.StickMove(controllerName, axisName, value);
        }
    }

    /// <summary>
    /// 左右アナログスティック押下時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="axisName">押下された軸の名前</param>
    public void NotifyStickDown(string controllerName, string axisName)
    {
        foreach (var observer in observers)
        {
            observer.OnStickDown(controllerName, axisName);
        }
    }

    /// <summary>
    /// 左右アナログスティック離上時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="axisName">離上された軸の名前</param>
    public void NotifyStickUp(string controllerName, string axisName)
    {
        foreach (var observer in observers)
        {
            observer.OnStickUp(controllerName, axisName);
        }
    }

    /// <summary>
    /// トリガー押下時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="triggerName">押下されたトリガーの名前</param>
    public void NotifyTriggerDown(string controllerName, string triggerName)
    {
        foreach (var observer in observers)
        {
            observer.OnTriggerDown(controllerName, triggerName);
        }
    }

    /// <summary>
    /// トリガー離上時の通知
    /// </summary>
    /// <param name="controllerName">コントローラーの名前</param>
    /// <param name="triggerName">離上されたトリガーの名前</param>
    public void NotifyTriggerUp(string controllerName, string triggerName)
    {
        foreach (var observer in observers)
        {
            observer.OnTriggerUp(controllerName, triggerName);
        }
    }

    private void Update()
    {
        // コントローラーの接続状態をチェック
        CheckControllerConnections();

        // コントローラーの入力をチェック
        CheckControllerInputs();
    }

    /// <summary>
    /// コントローラーの接続状態を確認
    /// </summary>
    private void CheckControllerConnections()
    {
        // 新しいコントローラーが接続された場合
        // NotifyControllerConnected("ControllerName");

        // コントローラーが切断された場合
        // NotifyControllerDisconnected("ControllerName");
    }

    /// <summary>
    /// コントローラーの入力を確認
    /// </summary>
    private void CheckControllerInputs()
    {
        // ボタンが押された場合
        // NotifyButtonDown("ControllerName", "ButtonName");

        // ボタンが離された場合
        // NotifyButtonUp("ControllerName", "ButtonName");

        // スティックが動いた場合
        foreach (var gamepad in Gamepad.all)
        {
            Vector2 leftStick = gamepad.leftStick.ReadValue();
            if (leftStick.magnitude > 0.1f)
                NotifyStickMove(gamepad.displayName, "Left", leftStick);
            // 右スティックも同様に実装
        }

        // スティックが押された場合
        // NotifyStickDown("ControllerName", "AxisName");

        // スティックが離された場合
        // NotifyStickUp("ControllerName", "AxisName");

        // トリガーが押された場合
        // NotifyTriggerDown("ControllerName", "TriggerName");

        // トリガーが離された場合
        // NotifyTriggerUp("ControllerName", "TriggerName");
    }
}