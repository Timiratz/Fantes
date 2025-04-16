using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonLoader
{
    // サウンドファイルのパスを読み込むメソッド
    public static Dictionary<string, string> LoadSoundPaths(string jsonFilePath)
    {
        // 結果を格納する辞書
        Dictionary<string, string> soundPaths = new Dictionary<string, string>();

        try
        {
            // JSONファイルを文字列として読み込む
            string jsonContent = File.ReadAllText(jsonFilePath);

            // JSONデータを辞書形式に変換
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

    // JSONデータを辞書形式で扱うためのラッパークラス
    [System.Serializable]
    private class SoundPathWrapper
    {
        public Dictionary<string, string> soundPaths;
    }
}
