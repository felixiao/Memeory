using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    CardInfo cardInfo;
    Material frontMat;
    ResourceMgr resMgr;
	// Use this for initialization
	void Start () {
        frontMat = this.transform.GetChild(1).GetComponent<Renderer>().material;
        resMgr = Camera.main.GetComponent<ResourceMgr>();
        cardInfo = new CardInfo(CardInfo.CardShape.Club,0);
        //SetCardContent(shape, num);
	}
	
    public void SetCardContent(CardInfo.CardShape shape,int num)
    {
        cardInfo.shape = shape;
        cardInfo.number = num;
        frontMat.mainTexture = resMgr.GetTexture(cardInfo.shape, cardInfo.number);
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

