using UnityEngine;

public class KeyboardObserver : MonoBehaviour, IKeyboardObserver
{
    // ���͂̊Ď� ==============================
    public void OnKeyDown(KeyCode key)
    {
        //Debug.Log($"�L�[���� : {key}");
    }
    public void OnKeyUp(KeyCode key)
    {
        //Debug.Log($"�L�[���� : {key}");
    }
}
