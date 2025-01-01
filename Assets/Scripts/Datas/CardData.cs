using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// スキルの種類
/// </summary>
public enum CardType
{
    説得,
    反論,
    法律
    // 他にもあれば追加

}

public enum EffectType
{
    アタック,
    ブロック,
    回復
}

[Serializable]
public class CardData
{
    public string id;
    public string cardName;
    public int cost;
    public CardType cardType;
    public EffectType effectType;
    public int effectPower;
    public string effectDescription;
    


    /// <summary>
    /// コストラクタ
    /// </summary>
    /// <param name="datas"></param>
    public CardData(string[] datas)
    {

        // 取得した情報の確認
        for (int i = 0; i < datas.Length; i++)
        {
            Debug.Log(datas[i]);
        }

        // 取得した情報をキャストして代入
        id = datas[0];
        cardName = datas[1];
        cost = int.Parse(datas[2]);
        cardType = (CardType)Enum.Parse(typeof(CardType), datas[3]);
        effectType = (EffectType)Enum.Parse(typeof(EffectType), datas[4]);
        effectPower = int.Parse(datas[5]);
        effectDescription = datas[6];
    }
}