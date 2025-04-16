using UnityEngine;

public class Attack1Test : ITestState
{
    private bool isNextAttack = false; // 次の攻撃の予約
    private bool isButtonReleased = false; // ボタンが離されたかどうか

    public void EnterState(TestController player)
    {
        player.PlayerWeaponCollider(true);
        // 攻撃音を再生する
        Sound.Instance.PlaySE("NoHitSlash1");
        // 攻撃アニメーションの設定
        player.animator.SetBool("IsFinishAttack", false);
        player.animator.SetBool("IsAttack1", true);
        player.animator.speed = 1.0f;

        // 攻撃方向の設定
        Vector3 cameraForward = Vector3.Scale(player.GetCameraForward(), new Vector3(1, 0, 1)).normalized;
        player.transformTest.velocity = Vector3.zero;
        player.transformTest.quaternion = Quaternion.LookRotation(cameraForward);

        isButtonReleased = false; // ボタンが離された状態をリセット
        isNextAttack     = false; // 次の攻撃の予約をリセット
    }

    public void UpdateState(TestController player)
    {
        // ボタンが離されたかどうか
        if (InputManager.Instance.IsAttackRelease && !isButtonReleased && !isNextAttack)
            isButtonReleased = true;
        if (InputManager.Instance.IsAttackPressed && isButtonReleased && !isNextAttack)
            isNextAttack = true;

        // 現在のアニメーション情報を取得
        AnimatorStateInfo currentStateInfo = player.animator.GetCurrentAnimatorStateInfo(0);
        // 次の攻撃の予約があり、ボタンが離された場合
        if (isNextAttack)
        {
            // 次の攻撃
            player.animator.SetBool("IsAttack1", false);
            player.ChangeState(new Attack2Test());
            return;
        }

        // アニメーション１の再生が終了した場合
        if (currentStateInfo.IsName("TestAttack1") && currentStateInfo.normalizedTime >= 0.5f)
        {
            NextState(player); // 次の状態に遷移
        }
    }

    private void NextState(TestController player)
    {
        player.animator.SetBool("IsFinishAttack", true);
        player.animator.SetBool("IsAttack1", false);
        player.animator.SetBool("IsAttack2", false);
        player.PlayerWeaponCollider(false);
        // スティックが倒されている場合
        if (InputManager.Instance.MovementInput.sqrMagnitude > 0.01f)
        {
            // ダッシュ状態に遷移
            player.ChangeState(new DashTest());
        }
        // スティックが倒されていない場合
        else
        {
            // スタンド状態に遷移
            player.ChangeState(new StandTest());
        }
    }
}
