using UnityEngine;
using System.Collections;

public class CardMgr : MonoBehaviour {

    Deck deck;
    int curIndex=0;
    public GameObject cardPrefab;
    GameObject newCard;
    public int deckLength;
    public Canvas canvas_ui;
	// Use this for initialization
	void Start () {
        deck = new Deck();
        InitDeck();
        DrawACard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void InitDeck()
    {
        deck.Init();
        //Deck.Instance.Sort();
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
        if (curIndex <deckLength)
        {
            CreateNewCard();
            curIndex++;
            if (curIndex == deckLength)
            {
                OnDrawLastCard();
            }
        }
    }
    private void CreateNewCard()
    {
        newCard = GameObject.Instantiate(cardPrefab);
        newCard.transform.parent = this.transform;
        CardBehaviour cardBh = newCard.GetComponent<CardBehaviour>();
        cardBh.cardManager = this.gameObject;
        Card card = newCard.GetComponent<Card>();
        CardInfo ci = deck.GetCard(curIndex);
        card.SetCardContent(curIndex, ci);
    }
    /// <summary>
    /// Call once when draw the last card but before put into any assembly
    /// </summary>
    private void OnDrawLastCard()
    {
        //do not show next card

    }

    public void OnCardClassified()
    {
        if (curIndex < deckLength)
        {
            DrawACard();
            if (curIndex == deckLength)
            {
                OnSortFinish();
            }
        }
    }
    /// <summary>
    /// Call once when the last card put to an assembly
    /// </summary>
    private void OnSortFinish()
    {
        //Show Result panel
        UI_PanelResult ui_pr = canvas_ui.GetComponent<UI_PanelResult>();
        ui_pr.ShowResult(14, 29);
    }
    public void Btn_PlayAgain_Click()
    {
        for (int i = this.transform.childCount-1; i > 0; i--)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
        ResetDeck();
    }
}
