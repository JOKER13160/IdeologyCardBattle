using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("デッキ関連")]
    public CardDataSO allCardsSO; // 全カード情報を保持するSO
    [SerializeField] private List<CardData> deck = new(); // プレイヤーのデッキ
    public List<CardData> hand = new(); // 手札
    [SerializeField] private List<CardData> discardPile = new(); // 捨て札
    [SerializeField] private int energy; // カードのリソース

    [Header("初期設定")]
    public List<CardIDCount> initialDeckSetup; // 初期デッキ (カードIDと枚数)
    public int startHandCount; //初期手札の枚数

    [Header("デッキ設定")]
    public int maxHandSize = 10; // 手札の最大枚数

    [Header("UI設定")]
    [SerializeField] private UIManager UIManager;


    private void Start()
    {
        // 初期デッキを構築
        InitializeDeckWithIDCounts(initialDeckSetup);
        // 初期手札を引く
        MultiDrawCards(startHandCount);
    }

    /// <summary>
    /// 指定されたIDと枚数でデッキを初期化する
    /// </summary>
    /// <param name="cardIDCounts">初期デッキに含めるカードIDとその枚数のリスト</param>
    private void InitializeDeckWithIDCounts(List<CardIDCount> cardIDCounts)
    {
        foreach (var cardIDCount in cardIDCounts)
        {
            // カードIDに対応するカードデータを取得
            CardData card = allCardsSO.cardDatasList.FirstOrDefault(c => c.id == cardIDCount.id);
            if (card == null)
            {
                Debug.LogWarning($"ID: {cardIDCount.id} に対応するカードが見つかりませんでした。");
                continue;
            }

            // 指定された枚数だけデッキに追加
            for (int i = 0; i < cardIDCount.count; i++)
            {
                deck.Add(card);
            }
        }

        if (deck.Count == 0)
        {
            Debug.LogWarning("初期デッキにカードが設定されていません！");
        }
        else
        {
            Debug.Log($"初期デッキに{deck.Count}枚のカードを設定しました");
        }

        ShuffleDeck();
    }

    /// <summary>
    /// デッキをシャッフルする
    /// </summary>
    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardData temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        for (int i = 0; i < deck.Count; i++)
        {
            Debug.Log("デッキに「" + deck[i].cardName + "」を設定しました");
        }
    }

    /// <summary>
    /// カードを1枚引く
    /// </summary>
    public void DrawCard()
    {
        if (hand.Count >= maxHandSize)
        {
            Debug.LogWarning("手札がいっぱいです！");
            return;
        }

        if (deck.Count == 0)
        {
            if (discardPile.Count > 0)
            {
                Debug.Log("デッキが空なので、捨て札をシャッフルしてデッキに戻します");
                RefillDeckFromDiscard();
            }
            else
            {
                Debug.LogWarning("デッキも捨て札も空です！");
                return;
            }
        }
        UIManager.HandUI(deck[0]);
        CardData drawnCard = deck[0];
        
        deck.RemoveAt(0);
        hand.Add(drawnCard);

        Debug.Log($"カードを引きました: {drawnCard.cardName}");
        
    }

    /// <summary>
    /// 手札からカードを使用する
    /// </summary>
    /// <param name="cardIndex">使用するカードのインデックス</param>
    public void PlayCard(int cardIndex)
    {
        if (cardIndex < 0 || cardIndex >= hand.Count)
        {
            Debug.LogWarning("指定されたカードは手札にありません！");
            return;
        }

        CardData playedCard = hand[cardIndex];
        hand.RemoveAt(cardIndex);
        discardPile.Add(playedCard);

        Debug.Log($"カードを使用しました: {playedCard.cardName}");
    }

    /// <summary>
    /// 捨て札をデッキに戻し、シャッフルする
    /// </summary>
    private void RefillDeckFromDiscard()
    {
        deck.AddRange(discardPile);
        discardPile.Clear();
        ShuffleDeck();
    }

    /// <summary>
    /// デッキにカードを追加する
    /// </summary>
    /// <param name="card">追加するカード</param>
    public void AddCardToDeck(CardData card)
    {
        deck.Add(card);
        Debug.Log($"カードをデッキに追加しました: {card.cardName}");
    }

    /// <summary>
    /// デッキからカードを削除する
    /// </summary>
    /// <param name="card">削除するカード</param>
    public void RemoveCardFromDeck(CardData card)
    {
        if (deck.Remove(card))
        {
            Debug.Log($"カードをデッキから削除しました: {card.cardName}");
        }
        else
        {
            Debug.LogWarning($"指定されたカードはデッキに存在しません: {card.cardName}");
        }
    }

    /// <summary>
    /// 指定した回数だけカードを引く関数を動かす
    /// </summary>
    /// <param name="n">引くカードの枚数</param>
    public void MultiDrawCards(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DrawCard();
        }
    }
}

/// <summary>
/// 初期デッキ用のデータ (カードIDと枚数)
/// </summary>
[System.Serializable]
public class CardIDCount
{
    public string id; // カードの一意な識別子
    public int count; // カードの枚数
}
