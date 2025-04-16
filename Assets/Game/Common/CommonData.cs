/// <summary>
/// 共通データクラス
/// </summary>
public class CommonData : Singleton<CommonData>
{
    /// <summary>
    /// 重力値（Y座標）
    /// </summary>
    public float GravityY = 0.01f;
    /// <summary>
    /// 摩擦値（XとZ座標）
    /// </summary>
    public float Friction = 0.91f;
}
