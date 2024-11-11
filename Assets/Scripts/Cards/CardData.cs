using System;
using UnityEngine;

/// <summary>
/// スキルの種類
/// </summary>
public enum CostType
{
    資金,
    思想
}

public enum CardType
{
    攻撃,
    防御,
    経済,
    諜報,
    キャピタル,
    持続,
    無し
    // 他にもあれば追加

}

public enum EffectType
{

}

[Serializable]
public class CardData
{
    public string id;
    public string cardName;
    public CostType costType;
    public int cost;
    public CardType card1Type;
    public CardType card2Type;
    public EffectType effect1Type;
    public int effect1Power;
    public EffectType effect2Type;
    public int effect2Power;
    public EffectType effect3Type;
    public int effect3Power;
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
        costType = (CostType)Enum.Parse(typeof(CostType), datas[2]);
        cost = int.Parse(datas[3]);
        card1Type = (CardType)Enum.Parse(typeof(CardType), datas[4]);
        card2Type = (CardType)Enum.Parse(typeof(CardType), datas[5]);
        effect1Type = (EffectType)Enum.Parse(typeof(EffectType), datas[6]);
        effect1Power = int.Parse(datas[7]);
        effect2Type = (EffectType)Enum.Parse(typeof(EffectType), datas[8]);
        effect2Power = int.Parse(datas[9]);
        effect3Type = (EffectType)Enum.Parse(typeof(EffectType), datas[10]);
        effect3Power = int.Parse(datas[11]);
    }
}