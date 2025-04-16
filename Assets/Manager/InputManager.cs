using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �������̓}�l�[�W���[�N���X
/// </summary>
public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private ControllerSubject controllerSubject;
    [SerializeField] private KeyboardSubject keyboardSubject;
    [SerializeField] private ControllerObserver controllerObserver;
    [SerializeField] private KeyboardObserver keyboardObserver;

    // ���͏�ԃv���p�e�B
    public Vector2 MovementInput { get; private set; }  // �ړ����́iWASD�܂��͍��X�e�B�b�N���|�����j
    public bool IsDashPressed { get; private set; }  // �_�b�V���{�^���i��Shift�L�[�܂���ZL�{�^���j
    public bool IsJumpPressed { get; private set; }  // �W�����v�{�^���i�X�y�[�X�L�[�܂���B�{�^���j
    public bool IsAttackPressed { get; private set; }  // �U���{�^���i���N���b�N�܂���ZR�{�^��)
    public bool IsAttackRelease { get; private set; }  // �U���{�^���������ꂽ�i���N���b�N�܂���ZR�{�^���j
    public bool IsCameraTarget { get; private set; }  // �J�����^�[�Q�b�g�i�E�N���b�N�܂���L�{�^���j


    protected override void Awake()
    {
        // �����̃C���X�^���X������ꍇ�͔j��
        base.Awake();
        // ����������
        InitializeInputSystem();
    }

    /// <summary>
    /// ���̓V�X�e���̏�����
    /// </summary>
    private void InitializeInputSystem()
    {
        // �R���g���[���[�I�u�U�[�o�[�o�^
        controllerSubject.RegisterObserver(controllerObserver);

        // �L�[�{�[�h�I�u�U�[�o�[�o�^
        keyboardSubject.RegisterObserver(keyboardObserver);

        // �����f�o�C�X�̏����ʒm
        NotifyExistingDevices();
    }

    /// <summary>
    /// �ڑ��ς݃f�o�C�X�̏����ʒm
    /// </summary>
    private void NotifyExistingDevices()
    {
        foreach (var device in InputSystem.devices)
        {
            if (device is Gamepad)
            {
                controllerSubject.NotifyControllerConnected(device.displayName);
            }
            else if (device is Keyboard)
            {
                keyboardSubject.NotifyKeyboardConnected();
            }
        }
    }

    private void Update()
    {
        // �L�[�{�[�h���͂̍X�V����
        UpdateKeyboardInputs();
        // �R���g���[���[���͂̍X�V����
        UpdateControllerInputs();
    }

    /// <summary>
    /// �L�[�{�[�h���͂̍X�V����
    /// </summary>
    private void UpdateKeyboardInputs()
    {
        // �ړ����́iWASD�L�[�j
        float horizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        float vertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        MovementInput = new Vector2(horizontal, vertical).normalized;

        // �_�b�V���i��Shift�L�[�j
        IsDashPressed = Input.GetKey(KeyCode.LeftShift);

        // �W�����v�i�X�y�[�X�L�[�j
        IsJumpPressed = Input.GetKey(KeyCode.Space);

        // �U���i���N���b�N�j
        IsAttackPressed = Input.GetMouseButton(0);
        // �U���{�^���������ꂽ�i���N���b�N�j
        IsAttackRelease = Input.GetMouseButtonUp(0);

        // �J�����^�[�Q�b�g�i�E�N���b�N�j
        IsCameraTarget = Input.GetMouseButton(1);
    }

    /// <summary>
    /// �R���g���[���[���͂̍X�V����
    /// </summary>
    private void UpdateControllerInputs()
    {
        // �R���g���[���[���ڑ�����Ă���ꍇ
        if (Gamepad.current != null)
        {
            // �ړ����́i���X�e�B�b�N�j
            Vector2 stickInput = Gamepad.current.leftStick.ReadValue();
            // �X�e�B�b�N�������Ă���ꍇ�͈ړ����͂��X�V
            if (stickInput.sqrMagnitude > 0.01f)
            {
                MovementInput = stickInput;
            }
            else
            {
                // �X�e�B�b�N�������Ă��Ȃ��ꍇ�͈ړ����͂����Z�b�g
                MovementInput = Vector2.zero;
            }

            // �_�b�V���iZL�{�^���j
            IsDashPressed = Gamepad.current.leftTrigger.isPressed;

            // �W�����v�iB�{�^���j
            IsJumpPressed = Gamepad.current.buttonSouth.isPressed;

            // �U���iZR�{�^���j
            IsAttackPressed = Gamepad.current.rightTrigger.isPressed;
            // �U���{�^���������ꂽ�iZR�{�^���j
            IsAttackRelease = Gamepad.current.rightTrigger.wasReleasedThisFrame;

            // �J�����^�[�Q�b�g�iL�{�^���j
            IsCameraTarget = Gamepad.current.leftShoulder.isPressed;
        }
    }
    // ���͕����̐؂�ւ��͌��ݎ�������Ă��܂���

    private void OnDestroy()
    {
        // �R���g���[���[�I�u�U�[�o�[����
        if (controllerSubject != null && controllerObserver != null) controllerSubject.UnregisterObserver(controllerObserver);
        // �L�[�{�[�h�I�u�U�[�o�[����
        if (keyboardSubject != null && keyboardObserver != null) keyboardSubject.UnregisterObserver(keyboardObserver);
    }
}
