using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    void Start()
    {
        // VSync�𖳌���
        QualitySettings.vSyncCount = 0;

        // �t���[�����[�g���Œ�
        Application.targetFrameRate = 120;
    }
}
