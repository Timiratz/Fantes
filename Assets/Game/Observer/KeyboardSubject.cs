using System.Collections.Generic;
using UnityEngine;

public class KeyboardSubject : MonoBehaviour
{
    // �I�u�U�[�o�[���X�g
    private List<IKeyboardObserver> observers = new List<IKeyboardObserver>();

    /// <summary>
    /// �I�u�U�[�o�[��o�^
    /// </summary>
    public void RegisterObserver(IKeyboardObserver observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// �I�u�U�[�o�[������
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
    /// �L�[�������ɒʒm
    /// </summary>
    public void NotifyKeyDown(KeyCode key)
    {
        foreach (var observer in observers)
        {
            observer.OnKeyDown(key);
        }
    }

    /// <summary>
    /// �L�[���㎞�ɒʒm
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
        // �L�[���͂��Ď�
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                NotifyKeyDown(key);  // �L�[�����ʒm
            }
            if (Input.GetKeyUp(key))
            {
                NotifyKeyUp(key);    // �L�[����ʒm
            }
        }
    }
}
