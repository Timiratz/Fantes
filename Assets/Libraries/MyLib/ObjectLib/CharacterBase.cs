using UnityEngine;

/// <summary>
/// キャラクターの基底クラス
/// </summary>
public abstract class CharacterBase : ObjectBase
{
    // キャラクターのデータ構造体
    [SerializeField] private CharacterData m_characterData;

    // トランスフォームのデータ構造体
    [SerializeField] private TransformData m_transformData;

    // キャラクターのデータの取得・設定
    public CharacterData characterData
    {
        get { return m_characterData; }
        set { m_characterData = value; }
    }

    // トランスフォームのデータの取得・設定
    public TransformData transformData
    {
        get { return m_transformData; }
        set { m_transformData = value; }
    }
}
