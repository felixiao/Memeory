using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Deck
{
    public List<CardInfo> cards = new List<CardInfo>();
    public List<int> cardIndex = new List<int>();
    public void Init()
    {
        cards.Clear();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                cards.Add(new CardInfo((CardInfo.CardShape)i, j));
            }
        }
        Sort();
    }
    /// <summary>
    /// sort the deck, just for initial
    /// </summary>
    public void Sort()
    {
        cardIndex.Clear();
        for (int i = 0; i < 52; i++)
        {
            cardIndex.Add(i);
        }
    }
    /// <summary>
    /// shuffle the deck
    /// </summary>
    public void Shuffle()
    {
        if (cardIndex.Count != 52)
        {
            Sort();
        }
        for (int i = 1; i < 52; i++)
        {
            int index = Random.Range(0, i);
            int temp = cardIndex[index];
            cardIndex[index] = cardIndex[i];
            cardIndex[i] = temp;
        }
        OutputIndex();
    }
    public CardInfo GetCard(int index)
    {
        if (index < 52 && index >= 0)
            return cards[cardIndex[index]];
        else
            return null;
    }
    public void OutputIndex()
    {
        for (int i = 0; i < 52; i++)
        {
            Debug.Log("[" + i + "] " + cards[cardIndex[i]].ToString());
        }
    }
}
