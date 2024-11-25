using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]public TMP_Text turnText;
    //関数が始まったら、文字列を取得
    //"ターン目"で分ける
    //数字の部分をint型に置き換え、+1

    public void TurnEnd()
    {
        string turnCountText0 = turnText.text.Split(' ')[0];
        string turnCountText1 = turnText.text.Split(' ')[1];
        int turnCount = Int32.Parse(turnCountText0)+1;
        Debug.Log("ターン数："+turnCount);
        string turnCountText = turnCount.ToString() + " " + turnCountText1;
        Debug.Log(turnCountText);
        turnText.text = turnCountText;
    }
}
