using UnityEngine;
using System.Collections;

public class CardMgr : MonoBehaviour {
    Deck deck;
    int curIndex=0;
    public GameObject cardPrefab;
    GameObject newCard;
	// Use this for initialization
	void Start () {
        deck = new Deck();
        InitDeck();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void InitDeck()
    {
        deck.Init();
        deck.Sort();
        deck.Shuffle();
    }
    public void ResetDeck()
    {
        deck.Shuffle();
    }
    /// <summary>
    /// Draw a card from deck
    /// </summary>
    public void DrawACard()
    {
        curIndex++;
        CreateNewCard();
        if (curIndex == 51)
        {
            OnDrawLastCard();
        }
    }
    public void CreateNewCard()
    {
        newCard = GameObject.Instantiate(cardPrefab);
        Card card = newCard.GetComponent<Card>();
        card.cardInfo = deck.GetCard(curIndex);
        newCard.name = "[" + curIndex + "] " + card.cardInfo.ToString();
        newCard.transform.parent = this.transform;
    }
    /// <summary>
    /// Call once when draw the last card but before put into any assembly
    /// </summary>
    public void OnDrawLastCard()
    {
        //do not show next card
    }
    /// <summary>
    /// Call once when the last card put to an assembly
    /// </summary>
    public void OnSortFinish()
    {
        //Show Result panel
    }
    public void OnCardClassified()
    {
        DrawACard();
    }
}
