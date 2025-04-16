using Unity.VisualScripting;

// 共通データクラス
public class CommonData : Singleton<CommonData>
{
    // 重力値（Y座標）
    public float GravityY = 0.01f;
    // 摩擦値（XとZ座標）
    public float Friction = 0.91f;
}
