using UnityEngine;

public class KeyboardObserver : MonoBehaviour, IKeyboardObserver
{
    // 入力の監視 ==============================
    public void OnKeyDown(KeyCode key)
    {
        //Debug.Log($"キー押下 : {key}");
    }
    public void OnKeyUp(KeyCode key)
    {
        //Debug.Log($"キー離上 : {key}");
    }
}
