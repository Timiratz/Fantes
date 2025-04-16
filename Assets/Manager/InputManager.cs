using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 統合入力マネージャークラス
/// </summary>
public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] private ControllerSubject controllerSubject;
    [SerializeField] private KeyboardSubject keyboardSubject;
    [SerializeField] private ControllerObserver controllerObserver;
    [SerializeField] private KeyboardObserver keyboardObserver;

    // 入力状態プロパティ
    public Vector2 MovementInput { get; private set; }  // 移動入力（WASDまたは左スティックが倒される）
    public bool IsDashPressed { get; private set; }  // ダッシュボタン（左ShiftキーまたはZLボタン）
    public bool IsJumpPressed { get; private set; }  // ジャンプボタン（スペースキーまたはBボタン）
    public bool IsAttackPressed { get; private set; }  // 攻撃ボタン（左クリックまたはZRボタン)
    public bool IsAttackRelease { get; private set; }  // 攻撃ボタンが離された（左クリックまたはZRボタン）
    public bool IsCameraTarget { get; private set; }  // カメラターゲット（右クリックまたはLボタン）


    protected override void Awake()
    {
        // 既存のインスタンスがある場合は破棄
        base.Awake();
        // 初期化処理
        InitializeInputSystem();
    }

    /// <summary>
    /// 入力システムの初期化
    /// </summary>
    private void InitializeInputSystem()
    {
        // コントローラーオブザーバー登録
        controllerSubject.RegisterObserver(controllerObserver);

        // キーボードオブザーバー登録
        keyboardSubject.RegisterObserver(keyboardObserver);

        // 既存デバイスの初期通知
        NotifyExistingDevices();
    }

    /// <summary>
    /// 接続済みデバイスの初期通知
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
        // キーボード入力の更新処理
        UpdateKeyboardInputs();
        // コントローラー入力の更新処理
        UpdateControllerInputs();
    }

    /// <summary>
    /// キーボード入力の更新処理
    /// </summary>
    private void UpdateKeyboardInputs()
    {
        // 移動入力（WASDキー）
        float horizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        float vertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        MovementInput = new Vector2(horizontal, vertical).normalized;

        // ダッシュ（左Shiftキー）
        IsDashPressed = Input.GetKey(KeyCode.LeftShift);

        // ジャンプ（スペースキー）
        IsJumpPressed = Input.GetKey(KeyCode.Space);

        // 攻撃（左クリック）
        IsAttackPressed = Input.GetMouseButton(0);
        // 攻撃ボタンが離された（左クリック）
        IsAttackRelease = Input.GetMouseButtonUp(0);

        // カメラターゲット（右クリック）
        IsCameraTarget = Input.GetMouseButton(1);
    }

    /// <summary>
    /// コントローラー入力の更新処理
    /// </summary>
    private void UpdateControllerInputs()
    {
        // コントローラーが接続されている場合
        if (Gamepad.current != null)
        {
            // 移動入力（左スティック）
            Vector2 stickInput = Gamepad.current.leftStick.ReadValue();
            // スティックが動いている場合は移動入力を更新
            if (stickInput.sqrMagnitude > 0.01f)
            {
                MovementInput = stickInput;
            }
            else
            {
                // スティックが動いていない場合は移動入力をリセット
                MovementInput = Vector2.zero;
            }

            // ダッシュ（ZLボタン）
            IsDashPressed = Gamepad.current.leftTrigger.isPressed;

            // ジャンプ（Bボタン）
            IsJumpPressed = Gamepad.current.buttonSouth.isPressed;

            // 攻撃（ZRボタン）
            IsAttackPressed = Gamepad.current.rightTrigger.isPressed;
            // 攻撃ボタンが離された（ZRボタン）
            IsAttackRelease = Gamepad.current.rightTrigger.wasReleasedThisFrame;

            // カメラターゲット（Lボタン）
            IsCameraTarget = Gamepad.current.leftShoulder.isPressed;
        }
    }
    // 入力方式の切り替えは現在実装されていません

    private void OnDestroy()
    {
        // コントローラーオブザーバー解除
        if (controllerSubject != null && controllerObserver != null) controllerSubject.UnregisterObserver(controllerObserver);
        // キーボードオブザーバー解除
        if (keyboardSubject != null && keyboardObserver != null) keyboardSubject.UnregisterObserver(keyboardObserver);
    }
}
