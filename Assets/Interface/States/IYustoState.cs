public interface IYustoState
{
    // 状態開始時の処理
    public abstract void EnterState(Yusto player);

    // 状態更新処理
    public abstract void UpdateState(Yusto player);
}
