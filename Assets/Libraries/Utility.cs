using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���[�e�B���e�B�֐���񋟂���ÓI�N���X
/// </summary>
public static class Utility
{
    // ========== �萔 ==========
    public const float PI = 3.141593f; // �~����

    // ========== �֐��n ==========

    /// <summary>
    /// ���S�ȃ���������iUnity�ł͕s�v�Ȃ̂ő�֏����j
    /// </summary>
    public static void SafeDestroy(GameObject obj)
    {
        if (obj != null)
        {
            GameObject.Destroy(obj);
            obj = null;
        }
    }

    /// <summary>
    /// �����_���l�𐶐�����
    /// </summary>
    public static float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    /// <summary>
    /// �x�����烉�W�A���ւ̕ϊ�
    /// </summary>
    public static float DegreeToRadian(float angle)
    {
        return angle * PI / 180f;
    }

    /// <summary>
    /// ���W�A������x���ւ̕ϊ�
    /// </summary>
    public static float RadianToDegree(float radian)
    {
        return radian * 180f / PI;
    }

    /// <summary>
    /// ������W����^�[�Q�b�g���W�ւ̐��K���x�N�g����Ԃ�
    /// </summary>
    public static Vector3 PosToTargetNormalizeVec(Vector3 pos, Vector3 targetPos)
    {
        return (targetPos - pos).normalized;
    }

    /// <summary>
    /// ������W�Ƃ�����W�̒��ԓ_�����߂�
    /// </summary>
    public static Vector3 Pos1ToPos2DistanceCenter(Vector3 pos1, Vector3 pos2)
    {
        return (pos1 + pos2) / 2f;
    }

    /// <summary>
    /// ������W�Ƃ�����W�̋��������߂�
    /// </summary>
    public static float Distance(Vector3 pos1, Vector3 pos2)
    {
        return Vector3.Distance(pos1, pos2);
    }

    /// <summary>
    /// �N�����v�֐��i�l��͈͓��ɐ����j
    /// </summary>
    public static float Clamp(float value, float min, float max)
    {
        return Mathf.Clamp(value, min, max);
    }

    /// <summary>
    /// ���`��ԁiLerp�j
    /// </summary>
    public static float Lerp(float t, float start, float end)
    {
        return Mathf.Lerp(start, end, t);
    }

    /// <summary>
    /// �����_�ȉ��w�茅�Ő؂�̂Ă�
    /// </summary>
    public static float Truncate(float num, int prec)
    {
        float scale = Mathf.Pow(10f, prec);
        return Mathf.Floor(num * scale) / scale;
    }

    /// <summary>
    /// ���a���Ƀ^�[�Q�b�g�����݂��邩�m�F����
    /// </summary>
    public static bool FindRadius(Vector3 you, Vector3 target, float radius)
    {
        return (target - you).sqrMagnitude <= radius * radius;
    }

    /// <summary>
    /// �Q�̈ʒu�x�N�g���Ԃ̊p�x���v�Z����֐�
    /// </summary>
    public static float CalculationAngle(Vector3 you, Vector3 target)
    {
        // �^�[�Q�b�g�����x�N�g���擾
        Vector3 forward = (target - you).normalized;
        // ���ς���p�x�擾
        float angle = Mathf.Acos(Vector3.Dot(forward, Vector3.forward));
        // �O�όv�Z�ŕ�������
        Vector3 crossProduct = Vector3.Cross(forward, Vector3.forward);
        // �O�ς��������Ȃ�}�C�i�X�ɂ���
        if (crossProduct.y < 0) angle = -angle;
        // ���W�A������x���ɕϊ����ĕԂ�
        return angle * Mathf.Rad2Deg;
    }

    /// <summary>
    /// �V�O���C�h�֐�����������
    /// </summary>
    public static float Sigmoid(float x)
    {
        return 1.0f / (1.0f + Mathf.Exp(-x));
    }

    /// <summary>
    /// �\�t�g�}�b�N�X�֐�����������
    /// </summary>
    public static List<float> Softmax(List<float> x)
    {
        // ���ʂ��i�[���郊�X�g
        List<float> result = new List<float>();
        // �w���֐��̘a���v�Z
        float sumExp = 0.0f;
        // �w���֐��̘a���v�Z
        foreach (float value in x)
            sumExp += Mathf.Exp(value);
        // �\�t�g�}�b�N�X�֐����v�Z
        foreach (float value in x)
            result.Add(Mathf.Exp(value) / sumExp);

        return result;
    }
}
