using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// デッキの種類
/// </summary>
public enum DeckType
{
    資本家,
    労働者,
    科学者,
    聖職者,
    司令官,
    農家,
    中流,
    役人
    // 他にもあれば追加
}

[Serializable]
public class DeckData
{
    public DeckType Name;
    public string Color;
    public string Description;
    public string Story;


    /// <summary>
    /// コストラクタ
    /// </summary>
    /// <param name="datas"></param>
    public DeckData(string[] datas)
    {

        // 取得した情報の確認
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }

        // 取得した情報をキャストして代入
        Name = (DeckType)Enum.Parse(typeof(DeckType), datas[0]);
        Color = datas[1];
        Description = datas[2];
        Story = datas[3];
    }
}