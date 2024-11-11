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
                case "オレンジ":
                    Color color;
                    if (ColorUtility.TryParseHtmlString("#FF9900", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("オレンジ");
                    break;

                case "赤":
                    deckImages[i].color = Color.red;
                    Debug.Log("赤");
                    break;

                case "水色":
                    deckImages[i].color = Color.cyan;
                    Debug.Log("水色");
                    break;

                case "白":
                    deckImages[i].color = Color.white;
                    Debug.Log("白");
                    break;

                case "茶色":
                    if (ColorUtility.TryParseHtmlString("#783F04", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("茶色");
                    break;

                case "緑":
                    deckImages[i].color = Color.green;
                    Debug.Log("緑");
                    break;

                case "青":
                    deckImages[i].color = Color.blue;
                    Debug.Log("青");
                    break;

                case "紫":
                    if (ColorUtility.TryParseHtmlString("#7300BF", out color))
                    {
                        deckImages[i].color = color;
                    }
                    Debug.Log("紫");
                    break;
            }
            
            
        }
    }
}
