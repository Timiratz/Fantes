using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    void Start()
    {
        // VSyncを無効化
        QualitySettings.vSyncCount = 0;

        // フレームレートを固定
        Application.targetFrameRate = 120;
    }
}
