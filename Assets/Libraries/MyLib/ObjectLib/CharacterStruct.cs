//-------------------------------------------------------------------------
// キャラクターのステータスを管理する構造体
//-------------------------------------------------------------------------
using UnityEngine;
[System.Serializable]
public struct CharacterData
{
    // ========== 状態フラグ ==========

    [Header("その場で立ち状態フラグ")]
    public bool standFlag;

    [Header("待機状態フラグ")]
    public bool waitFlag;

    [Header("守備状態フラグ")]
    public bool defenseFlag;

    [Header("移動状態フラグ")]
    public bool moveFlag;

    [Header("ノーマル攻撃フラグ")]
    public bool normalAttackFlag;

    [Header("ロックオン攻撃フラグ")]
    public bool lockOnAttackFlag;

    [Header("必殺技攻撃フラグ")]
    public bool attackSpecialFlag;

    [Header("生存フラグ")]
    public bool survivalFlag;

    [Header("存在フラグ")]
    public bool existFlag;

    [Header("回復フラグ")]
    public bool recoveryFlag;

    [Header("空中フラグ")]
    public bool airFlag;

    [Header("地面フラグ")]
    public bool earthFlag;

    [Header("ジャンプフラグ")]
    public bool jumpFlag;

    [Header("突進（ロックオン）フラグ")]
    public bool lockOnFlag;

    [Header("発見フラグ")]
    public bool insideFlag;

    [Header("追従フラグ")]
    public bool chaseFlag;

    [Header("勝利フラグ")]
    public bool winFlag;

    [Header("ロックオンチャージ中フラグ")]
    public bool lockOnChargeFlag;

    [Header("ロックオンチャージ完了フラグ")]
    public bool lockOnCompFlag;

    [Header("攻撃権限フラグ")]
    public bool attackFlag;

    [Header("パリィ成功フラグ")]
    public bool parryFlag;

    [Header("スポーン済みフラグ")]
    public bool popedFlag;

    [Header("ヒットストップ中フラグ")]
    public bool hitStopFlag;

    [Header("スタミナ使用可能フラグ")]
    public bool staminaFlag;

    [Header("行動可能状態フラグ")]
    public bool stateFlag;

    [Header("被ダメージ中フラグ")]
    public bool hitDamageFlag;

    // ========== 数値パラメータ ==========

    [Header("数値パラメータ")]

    [Header("向いている方向（角度）")]
    public float angle;

    [Header("移動速度")]
    public float moveSpeed;

    [Header("ノックバック力")]
    public float retreatPower;

    [Header("攻撃力の最大値")]
    public float attackPowerMax;

    [Header("現在の攻撃力")]
    public float attackPower;

    [Header("体力の最大値")]
    public float healthMax;

    [Header("現在の体力")]
    public float health;

    [Header("経験値")]
    public float exp;

    [Header("ロックオンカウント")]
    public int lockOnCount;             

    [Header("移動カウント")]
    public int moveCount;               

    [Header("武器パーティクル番号")]
    public int weaponParticleNum;       

    [Header("消滅までのカウント")]
    public int deleteCount;             

    [Header("回復カウント")]
    public int recoveryCount;           

    [Header("無敵時間")]
    public int safeCount;               

    [Header("被ダメージカウント")]
    public int moveStopCount;           

    [Header("ヒットストップカウント（多重ヒット防止）")]
    public int hitStopCount;            

    [Header("ヒットストップカウントの最大値")]
    public int hitStopCountMax;         

    [Header("攻撃した回数")]
    public int attackNum;               

    [Header("攻撃を当てた回数")]
    public int beAttackNum;             

    [Header("与えたダメージ")]
    public int gaveDamage;              

    [Header("追加ダメージ")]
    public int damagePlus;              

    [Header("レベルの最大値")]
    public int levelMax;                

    [Header("現在のレベル")]
    public int level;                                     

    [Header("スタミナの最大値")]
    public int staminaMax;              

    [Header("現在のスタミナ")]
    public int stamina;                               
}