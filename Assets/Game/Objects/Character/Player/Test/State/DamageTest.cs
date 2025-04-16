using UnityEngine;

public class DamageTest : ITestState
{
    private float elapsedTime = 0f;             // 経過時間

    public void EnterState(TestController player)
    {
        // アニメーションを設定する
        player.animator.SetBool("IsDefense1", false);
        player.animator.SetBool("IsRuning", false);
        player.animator.SetBool("IsDash", false);
        player.animator.SetBool("IsAvoid", false);
        player.animator.SetBool("IsDamage1", true);
        player.animator.speed = 1.2f;
        // 動いてはならない時間を設定する
        player.characterTest.moveStopCount = 30;
        // 無敵時間を設定する
        player.characterTest.safeCount = 60;
        // その他の初期化処理
        elapsedTime = 0f;
    }

    public void UpdateState(TestController player)
    {
        // 経過時間をフレーム数として加算
        elapsedTime += Time.deltaTime;

        // 攻撃ボタンを押した場合
        if (InputManager.Instance.IsAttackPressed)
        {
            player.ChangeState(new DefenseTest());
            return;
        }

        // 経過時間をフレーム数に変換して比較
        if ((int)(elapsedTime * 60) >= player.characterTest.moveStopCount)
        {
            elapsedTime = 0; 
            player.ChangeState(new StandTest());
        }
    }

}
