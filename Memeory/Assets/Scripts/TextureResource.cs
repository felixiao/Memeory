using UnityEngine;
using System.Collections;

public class TextureResource : MonoBehaviour {
    public Texture[] club;
    public Texture[] diamond;
    public Texture[] spade;
    public Texture[] heart;
    public Texture blank;
	// Use this for initialization
	void Start () {
        club = Resources.LoadAll<Texture>("club");
        diamond = Resources.LoadAll<Texture>("diamond");
        spade = Resources.LoadAll<Texture>("spade");
        heart = Resources.LoadAll<Texture>("heart");
        Debug.Log("Finish Loading");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public Texture GetTexture(SetCard.CardShape shape, int num)
    {
        Debug.Log(shape.ToString() + ", " + num);
        switch (shape)
        {
            case SetCard.CardShape.Club:
                return club[num];
            case SetCard.CardShape.Diamond:
                return diamond[num];
            case SetCard.CardShape.Heart:
                return heart[num];
            case SetCard.CardShape.Spade:
                return spade[num];
        }
        return blank;
    }
}
