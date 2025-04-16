/// <summary>
/// キャラクターの状態を表すインターフェース
/// </summary>
public interface IKingSlimeState
{
    /// <summary>
    /// 状態開始時の処理
    /// </summary>
    public abstract void EnterState(KingSlimeController slime);

    /// <summary>
    /// 状態更新処理
    /// </summary>
    public abstract void UpdateState(KingSlimeController slime);
}
