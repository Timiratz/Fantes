using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

/// <summary>
/// �R���g���[���[�̐ڑ���Ԃ��Ď����A���͏�Ԃ�ʒm����N���X
/// </summary>
public class ControllerSubject : MonoBehaviour
{
    // �I�u�U�[�o�[���X�g
    private List<IControllerObserver> observers = new List<IControllerObserver>();

    /// <summary>
    /// �I�u�U�[�o�[��o�^
    /// </summary>
    /// <param name="observer">�o�^����I�u�U�[�o�[</param>
    public void RegisterObserver(IControllerObserver observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// �I�u�U�[�o�[������
    /// </summary>
    /// <param name="observer">��������I�u�U�[�o�[</param>
    public void UnregisterObserver(IControllerObserver observer)
    {
        observers.Remove(observer);
    }

    private void OnEnable()
    {
        // InputSystem�̃f�o�C�X�ύX�C�x���g�ɓo�^
        InputSystem.onDeviceChange += HandleDeviceChange;
    }

    private void OnDisable()
    {
        // InputSystem�̃f�o�C�X�ύX�C�x���g�������
        InputSystem.onDeviceChange -= HandleDeviceChange;
    }

    /// <summary>
    /// �f�o�C�X�ڑ���Ԃ̕ύX��ʒm
    /// </summary>
    /// <param name="device">�ύX���ꂽ�f�o�C�X</param>
    /// <param name="change">�ύX�̎��</param>
    private void HandleDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Added:
                // �f�o�C�X���ڑ����ꂽ�ꍇ
                NotifyControllerConnected(device.displayName);
                break;
            case InputDeviceChange.Removed:
                // �f�o�C�X���ؒf���ꂽ�ꍇ
                NotifyControllerDisconnected(device.displayName);
                break;
        }
    }

    /// <summary>
    /// �R���g���[���[�ڑ����ɒʒm
    /// </summary>
    /// <param name="controllerName">�ڑ����ꂽ�R���g���[���[�̖��O</param>
    public void NotifyControllerConnected(string controllerName)
    {
        foreach (var observer in observers)
        {
            observer.OnControllerConnected(controllerName);
        }
    }

    /// <summary>
    /// �R���g���[���[�ؒf���ɒʒm
    /// </summary>
    /// <param name="controllerName">�ؒf���ꂽ�R���g���[���[�̖��O</param>
    public void NotifyControllerDisconnected(string controllerName)
    {
        foreach (var observer in observers)
        {
            observer.OnControllerDisconnected(controllerName);
        }
    }

    /// <summary>
    /// �e�{�^���������̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="buttonName">�����ꂽ�{�^���̖��O</param>
    public void NotifyButtonDown(string controllerName, string buttonName)
    {
        foreach (var observer in observers)
        {
            observer.OnButtonDown(controllerName, buttonName);
        }
    }

    /// <summary>
    /// �e�{�^�����㎞�̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="buttonName">�����ꂽ�{�^���̖��O</param>
    public void NotifyButtonUp(string controllerName, string buttonName)
    {
        foreach (var observer in observers)
        {
            observer.OnButtonUp(controllerName, buttonName);
        }
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�̈ړ��̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="axisName">�ړ��������̖��O</param>
    /// <param name="value">�ړ���</param>
    public void NotifyStickMove(string controllerName, string axisName, Vector2 value)
    {
        foreach (var observer in observers)
        {
            observer.StickMove(controllerName, axisName, value);
        }
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N�������̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="axisName">�������ꂽ���̖��O</param>
    public void NotifyStickDown(string controllerName, string axisName)
    {
        foreach (var observer in observers)
        {
            observer.OnStickDown(controllerName, axisName);
        }
    }

    /// <summary>
    /// ���E�A�i���O�X�e�B�b�N���㎞�̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="axisName">���コ�ꂽ���̖��O</param>
    public void NotifyStickUp(string controllerName, string axisName)
    {
        foreach (var observer in observers)
        {
            observer.OnStickUp(controllerName, axisName);
        }
    }

    /// <summary>
    /// �g���K�[�������̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="triggerName">�������ꂽ�g���K�[�̖��O</param>
    public void NotifyTriggerDown(string controllerName, string triggerName)
    {
        foreach (var observer in observers)
        {
            observer.OnTriggerDown(controllerName, triggerName);
        }
    }

    /// <summary>
    /// �g���K�[���㎞�̒ʒm
    /// </summary>
    /// <param name="controllerName">�R���g���[���[�̖��O</param>
    /// <param name="triggerName">���コ�ꂽ�g���K�[�̖��O</param>
    public void NotifyTriggerUp(string controllerName, string triggerName)
    {
        foreach (var observer in observers)
        {
            observer.OnTriggerUp(controllerName, triggerName);
        }
    }

    private void Update()
    {
        // �R���g���[���[�̐ڑ���Ԃ��`�F�b�N
        CheckControllerConnections();

        // �R���g���[���[�̓��͂��`�F�b�N
        CheckControllerInputs();
    }

    /// <summary>
    /// �R���g���[���[�̐ڑ���Ԃ��m�F
    /// </summary>
    private void CheckControllerConnections()
    {
        // �V�����R���g���[���[���ڑ����ꂽ�ꍇ
        // NotifyControllerConnected("ControllerName");

        // �R���g���[���[���ؒf���ꂽ�ꍇ
        // NotifyControllerDisconnected("ControllerName");
    }

    /// <summary>
    /// �R���g���[���[�̓��͂��m�F
    /// </summary>
    private void CheckControllerInputs()
    {
        // �{�^���������ꂽ�ꍇ
        // NotifyButtonDown("ControllerName", "ButtonName");

        // �{�^���������ꂽ�ꍇ
        // NotifyButtonUp("ControllerName", "ButtonName");

        // �X�e�B�b�N���������ꍇ
        foreach (var gamepad in Gamepad.all)
        {
            Vector2 leftStick = gamepad.leftStick.ReadValue();
            if (leftStick.magnitude > 0.1f)
                NotifyStickMove(gamepad.displayName, "Left", leftStick);
            // �E�X�e�B�b�N�����l�Ɏ���
        }

        // �X�e�B�b�N�������ꂽ�ꍇ
        // NotifyStickDown("ControllerName", "AxisName");

        // �X�e�B�b�N�������ꂽ�ꍇ
        // NotifyStickUp("ControllerName", "AxisName");

        // �g���K�[�������ꂽ�ꍇ
        // NotifyTriggerDown("ControllerName", "TriggerName");

        // �g���K�[�������ꂽ�ꍇ
        // NotifyTriggerUp("ControllerName", "TriggerName");
    }
}