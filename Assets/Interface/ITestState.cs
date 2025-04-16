/// <summary>
/// キャラクターの状態を表すインターフェース
/// </summary>
public interface ITestState
{
    /// <summary>
    /// 状態開始時の処理
    /// </summary>
    public abstract void EnterState(TestController player);

    /// <summary>
    /// 状態更新処理
    /// </summary>
    public abstract void UpdateState(TestController player);
}