using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [Header("カードプレハブ変数")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private TMP_Text cardNameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text cardTypeText;
    [SerializeField] private TMP_Text effectDescriptionText;
    [SerializeField] private GameObject handCardBox;



    public void HandUI(CardData drawnCard)
    {
        //cardNameText.text = drawnCard.cardName;
        //costText.text = drawnCard.cost.ToString();
        //cardTypeText.text = drawnCard.ToString();
        //effectDescriptionText.text = drawnCard.effectDescription;
        GameObject card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, handCardBox.transform);
        TextMeshProUGUI[] cardTexts = card.GetComponentsInChildren<TextMeshProUGUI>();

        cardTexts[0].text = drawnCard.cost.ToString();
        cardTexts[1].text = drawnCard.cardName;
        cardTexts[2].text = drawnCard.cardType.ToString();
        cardTexts[3].text = drawnCard.effectDescription;

        Debug.Log("1個目" + cardTexts[0].text);
        Debug.Log("2個目" + cardTexts[1].text);
        Debug.Log("3個目" + cardTexts[2].text);
        Debug.Log("4個目" + cardTexts[3].text);
    }
}
