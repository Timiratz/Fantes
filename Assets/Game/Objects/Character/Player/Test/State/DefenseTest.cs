using UnityEngine;

public class DefenseTest : ITestState
{
    private float elapsedTime = 0f;             // 経過時間

    public void EnterState(TestController player)
    {
        // アニメーションを設定する
        player.animator.SetBool("IsDamage1", false);
        player.animator.SetBool("IsDefense1", true);
        player.animator.speed = 1.0f;
        // 時間を設定する
        elapsedTime = 0f;
    }

    public void UpdateState(TestController player)
    {
        elapsedTime += Time.deltaTime;

        // 現在のアニメーション情報を取得
        AnimatorStateInfo currentStateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        // アニメーションが終了した場合
        if (currentStateInfo.IsName("TestDefense1") && currentStateInfo.normalizedTime >= 0.3f)
        {
            // 次の状態に遷移
            player.animator.SetBool("IsDefense1", false);
            player.ChangeState(new StandTest());
        }
    }
}
