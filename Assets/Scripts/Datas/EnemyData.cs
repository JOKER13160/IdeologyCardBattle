using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
    public Sprite sprite;

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
        // 画像のパスを設定（Assetsフォルダ内の指定フォルダ）
        string path = "Images/Enemies/" + datas[8];

        // 画像を取得
        Addressables.LoadAssetAsync<Sprite>(path).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                sprite = handle.Result;
            }
            else
            {
                Debug.LogError($"Failed to load sprite: {path}");
            }
        };
    }
}
