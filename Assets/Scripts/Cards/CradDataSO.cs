using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create CardDataSO", fileName = "CardDataSO")]
public class CardDataSO : ScriptableObject
{
    public List<CardData> cardDatasList = new();
}