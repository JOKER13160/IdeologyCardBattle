using UnityEngine;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public DeckManager deckManager;
    // このカードオブジェクトに対応するカードデータを保持する変数を追加
    // UIManager からカードデータをここに渡している
    public CardData cardData;
    // IPointerClickHandler の実装
    public void OnPointerClick(PointerEventData eventData)
    {
        int cardIndex = GetCardIndex();
        if (cardIndex != -1)
        {
            // エネルギーを消費する処理を追加
            // エネルギーが足りない場合はカードを使用できない
            if (cardData.cost > deckManager.energy)
            {
                // エネルギーが足りない場合はカードのコライダーを無効化
                GetComponent<BoxCollider2D>().enabled = false;
                Debug.LogWarning("エネルギーが足りません！");
                return;
            }
            // エネルギーを消費してカードを使用
            deckManager.energy -= cardData.cost;
            // カードをプレイする処理を追加
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
