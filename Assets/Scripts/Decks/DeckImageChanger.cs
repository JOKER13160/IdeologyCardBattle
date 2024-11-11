using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckImageChanger : MonoBehaviour
{
    public List<Image> deckImages = new List<Image>();
    public DeckDataSO deckDataSO;

    private void Start()
    {
        DeckImageChange();
    }
    private void DeckImageChange()
    {
        for (int i = 0; i < deckImages.Count; i++)
        {
            switch(deckDataSO.deckDatasList[i].Color)
            {
                case "�I�����W":
                    Color color;
                    if (ColorUtility.TryParseHtmlString("#FF9900", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("�I�����W");
                    break;

                case "��":
                    deckImages[i].color = Color.red;
                    Debug.Log("��");
                    break;

                case "���F":
                    deckImages[i].color = Color.cyan;
                    Debug.Log("���F");
                    break;

                case "��":
                    deckImages[i].color = Color.white;
                    Debug.Log("��");
                    break;

                case "���F":
                    if (ColorUtility.TryParseHtmlString("#783F04", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("���F");
                    break;

                case "��":
                    deckImages[i].color = Color.green;
                    Debug.Log("��");
                    break;

                case "��":
                    deckImages[i].color = Color.blue;
                    Debug.Log("��");
                    break;

                case "��":
                    if (ColorUtility.TryParseHtmlString("#7300BF", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("��");
                    break;
            }
            
            
        }
    }
}
