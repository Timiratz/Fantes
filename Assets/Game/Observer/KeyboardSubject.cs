using System.Collections.Generic;
using UnityEngine;

public class KeyboardSubject : MonoBehaviour
{
    // オブザーバーリスト
    private List<IKeyboardObserver> observers = new List<IKeyboardObserver>();

    /// <summary>
    /// オブザーバーを登録
    /// </summary>
    public void RegisterObserver(IKeyboardObserver observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// オブザーバーを解除
    /// </summary>
    public void UnregisterObserver(IKeyboardObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyKeyboardConnected()
    {
        Debug.Log("Keyboard connected");
    }

    /// <summary>
    /// キー押下時に通知
    /// </summary>
    public void NotifyKeyDown(KeyCode key)
    {
        foreach (var observer in observers)
        {
            observer.OnKeyDown(key);
        }
    }

    /// <summary>
    /// キー離上時に通知
    /// </summary>
    public void NotifyKeyUp(KeyCode key)
    {
        foreach (var observer in observers)
        {
            observer.OnKeyUp(key);
        }
    }

    private void Update()
    {
        // キー入力を監視
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                NotifyKeyDown(key);  // キー押下通知
            }
            if (Input.GetKeyUp(key))
            {
                NotifyKeyUp(key);    // キー離上通知
            }
        }
    }
}
