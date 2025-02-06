using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 敵のレア度を表す列挙型
/// </summary>
public enum Rarity
{
    Normal,
    Rare,
    SuperRare,
    Boss
}

/// <summary>
/// 敵のタイプ
/// </summary>

public enum EnemyType
{
    // 敵のタイプを列挙
    Attacker,
    Tank,
    Support,
    Boss
}
[Serializable]
public class EnemyData
{
    public string id;
    public Rarity rarity;
    public EnemyType enemyType;
    public string enemyName;
    public int attack;
    public int hp;
    public int exp;
    public int gold;
    public Image image;

    public EnemyData(string[] datas)
    {
        id = datas[0];
        rarity = (Rarity)System.Enum.Parse(typeof(Rarity), datas[1]);
        enemyType = (EnemyType)System.Enum.Parse(typeof(EnemyType), datas[2]);
        enemyName = datas[3];
        attack = int.Parse(datas[4]);
        hp = int.Parse(datas[5]);
        exp = int.Parse(datas[6]);
        gold = int.Parse(datas[7]);
        // Resources フォルダ内の Images/Enemy/ ディレクトリにある、
        // datas[8] で指定された名前の画像アセットを読み込み、それを image 変数に代入する
        image = Resources.Load<Image>("Images/Enemy/" + datas[8]);
    }
}
