using UnityEngine;

public class Yusto : CharacterBase
{
    private IYustoState   currentState;              // 現在の状態
    public  Animator      animatorYusto;             // ユスト騎士アニメーター

    [SerializeField] public float moveSpeed = 5.0f;  // プレイヤーの移動速度

    public void StartPlayer(PlayerController player)
    {
        
    }

    public void UpdatePlayer(PlayerController player)
    {
        // 現在の状態を更新
        currentState?.UpdateState(this);

    }

    // 状態を変更する
    public void ChangeState(IYustoState newState)
    {
        currentState = newState;       // 新しい状態に切り替え
        currentState.EnterState(this); // 新しい状態の開始処理を実行
    }
}
