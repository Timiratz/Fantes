using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader
{
    // �T�E���h�t�@�C���̃p�X��ǂݍ��ރ��\�b�h
    public static Dictionary<string, string> LoadSoundPaths(string jsonFilePath)
    {
        // ���ʂ��i�[���鎫��
        Dictionary<string, string> soundPaths = new Dictionary<string, string>();

        try
        {
            // JSON�t�@�C���𕶎���Ƃ��ēǂݍ���
            string jsonContent = File.ReadAllText(jsonFilePath);

            // JSON�f�[�^�������`���ɕϊ�
            soundPaths = JsonUtility.FromJson<SoundPathWrapper>(jsonContent).soundPaths;
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError($"JSON file not found: {e.Message}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load JSON: {e.Message}");
        }

        return soundPaths;
    }

    // JSON�f�[�^�������`���ň������߂̃��b�p�[�N���X
    [System.Serializable]
    private class SoundPathWrapper
    {
        public Dictionary<string, string> soundPaths;
    }
}
