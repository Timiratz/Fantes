using UnityEngine;

/// <summary>
/// �R���g���[���[�̓��͏�Ԃ��Ď�����C���^�[�t�F�[�X
/// </summary>
public interface IControllerObserver
{
    /// <summary>
    /// �R���g���[���[�ڑ����̒ʒm
    /// </summary>
    void OnControllerConnected(string controllerName);

    /// <summary>
    /// �R���g���[���[�ؒf���̒ʒm
    /// </summary>
    void OnControllerDisconnected(string controllerName);

    /// <summary>
    /// �e�{�^���������̒ʒm
    /// </summary>
    void OnButtonDown(string controllerName, string buttonName);

    /// <summary>
    /// �e�{�^�����㎞�̒ʒm
    /// </summary>
    void OnButtonUp(string controllerName, string buttonName);

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�̈ړ��̒ʒm
    /// </summary>
    void StickMove(string controllerName, string axisName, Vector2 value);

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�������̒ʒm
    /// </summary>
    void OnStickDown(string controllerName, string axisName);

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N���㎞�̒ʒm
    /// </summary>
    void OnStickUp(string controllerName, string axisName);

    /// <summary>
    /// �g���K�[�������̒ʒm
    /// </summary>
    void OnTriggerDown(string controllerName, string triggerName);

    /// <summary>
    /// �g���K�[���㎞�̒ʒm
    /// </summary>
    void OnTriggerUp(string controllerName, string triggerName);
}