using UnityEngine;

/// <summary>
/// �L�[�{�[�h�̓��͏�Ԃ��Ď�����C���^�[�t�F�[�X
/// </summary>
public interface IKeyboardObserver
{
    /// <summary>
    /// �L�[�������ꂽ�Ƃ��̒ʒm
    /// </summary>
    void OnKeyDown(KeyCode key);
    /// <summary>
    /// �L�[�������ꂽ�Ƃ��̒ʒm
    /// </summary>
    void OnKeyUp(KeyCode key);
}
