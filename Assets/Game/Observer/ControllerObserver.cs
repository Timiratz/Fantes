using UnityEngine;

/// <summary>
/// �R���g���[���[�̓��͏�Ԃ��Ď�����N���X
/// </summary>
public class ControllerObserver : MonoBehaviour, IControllerObserver
{
    /// <summary>
    /// �R���g���[���[�ڑ����̒ʒm
    /// </summary>
    public void OnControllerConnected(string controllerName)
    {
        //Debug.Log($"�R���g���[���[���ڑ�����܂��� : {controllerName}");
    }

    /// <summary>
    /// �R���g���[���[�ؒf���̒ʒm
    /// </summary>
    public void OnControllerDisconnected(string controllerName)
    {
        //Debug.Log($"�R���g���[���[���ؒf����܂��� : {controllerName}");
    }

    /// <summary>
    /// �e�{�^���������̒ʒm
    /// </summary>
    public void OnButtonDown(string controllerName, string buttonName)
    {
        //Debug.Log($"�{�^������ : {controllerName} - {buttonName}");
    }

    /// <summary>
    /// �e�{�^�����㎞�̒ʒm
    /// </summary>
    public void OnButtonUp(string controllerName, string buttonName)
    {
        //Debug.Log($"�{�^������ : {controllerName} - {buttonName}");
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�̈ړ��̒ʒm
    /// </summary>
    public void StickMove(string controllerName, string axisName, Vector2 value)
    {
        //Debug.Log($"�X�e�B�b�N�ړ� : {controllerName} - {axisName} - {value}");
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�������̒ʒm
    /// </summary>
    public void OnStickDown(string controllerName, string axisName)
    {
        //Debug.Log($"�X�e�B�b�N���� : {controllerName} - {axisName}");
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N���㎞�̒ʒm
    /// </summary>
    public void OnStickUp(string controllerName, string axisName)
    {
        //Debug.Log($"�X�e�B�b�N���� : {controllerName} - {axisName}");
    }

    /// <summary>
    /// �g���K�[�������̒ʒm
    /// </summary>
    public void OnTriggerDown(string controllerName, string triggerName)
    {
        //Debug.Log($"�g���K�[���� : {controllerName} - {triggerName}");
    }

    /// <summary>
    /// �g���K�[���㎞�̒ʒm
    /// </summary>
    public void OnTriggerUp(string controllerName, string triggerName)
    {
        //Debug.Log($"�g���K�[���� : {controllerName} - {triggerName}");
    }
}