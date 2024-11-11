using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create DeckDataSO", fileName = "DeckDataSO")]
public class DeckDataSO : ScriptableObject
{
    public List<DeckData> deckDatasList = new();
}