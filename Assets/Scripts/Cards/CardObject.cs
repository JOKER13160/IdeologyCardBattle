using UnityEngine;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public DeckManager deckManager;
    // このカードオブジェクトに対応するカードデータを保持する変数を追加
    public CardData cardData;
    // IPointerClickHandler の実装
    public void OnPointerClick(PointerEventData eventData)
    {
        int cardIndex = GetCardIndex();
        if (cardIndex != -1)
        {
            deckManager.PlayCard(cardIndex);
            // UI上のカードオブジェクトを削除する
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("カードのインデックスが見つかりませんでした！");
        }
    }

    private int GetCardIndex()
    {
        for (int i = 0; i < deckManager.hand.Count; i++)
        {

            if (deckManager.hand[i] == cardData)
            {
                return i;
            }
        }
        return -1; // インデックスが見つからなかった場合
    }

    // IPointerEnterHandler の実装
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Pointer entered {gameObject.name}");
        // 例: カードにハイライト表示を追加する処理
    }

    // IPointerExitHandler の実装
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Pointer exited {gameObject.name}");
        // 例: ハイライトを解除する処理
    }
}
