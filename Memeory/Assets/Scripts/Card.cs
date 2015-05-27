using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public int id;
    public CardInfo cardInfo;
    ResourceMgr resMgr;
	// Use this for initialization
	void Start () {
        
        cardInfo = new CardInfo(CardInfo.CardShape.Club,0);
        //SetCardContent(shape, num);
	}
    public void SetCardContent(int index, CardInfo info)
    {
        Debug.Log(info.ToString());
        cardInfo = info;
        id = index;
        this.name = "[" + index + "] " + info.ToString();
        Renderer rend = this.GetComponentInChildren<Renderer>();
        resMgr = Camera.main.GetComponent<ResourceMgr>();
        Texture t = resMgr.GetTexture(cardInfo.shape, cardInfo.number);
        rend.material.mainTexture = t;
    }
    public void SetCardContent(int index, CardInfo.CardShape shape,int num)
    {
        cardInfo.shape = shape;
        cardInfo.number = num;
        id = index;
        this.name = "[" + index + "] " + cardInfo.ToString();
        this.GetComponentInChildren<Renderer>().material.mainTexture = resMgr.GetTexture(cardInfo.shape, cardInfo.number);
    }
}
public class CardInfo
{
    public enum CardShape
    {
        Heart=0,
        Diamond=1,
        Club=2,
        Spade=3
    }

    public CardShape shape;
    public int number;

    public CardInfo(CardShape s, int n)
    {
        shape = s;
        number = n;
    }
    public override string ToString()
    {
        string[] s = { "♥", "♦", "♣", "♠" };
        return s[(int)shape] +" "+ number;
    }
}

