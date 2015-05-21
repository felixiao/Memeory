using UnityEngine;
using System.Collections;

public class ResourceMgr : MonoBehaviour {
    public Texture[] club;
    public Texture[] diamond;
    public Texture[] spade;
    public Texture[] heart;
    public Texture blank;
    // Use this for initialization
    void Start()
    {
        club = Resources.LoadAll<Texture>("club");
        diamond = Resources.LoadAll<Texture>("diamond");
        spade = Resources.LoadAll<Texture>("spade");
        heart = Resources.LoadAll<Texture>("heart");
        Debug.Log("Finish Loading");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Texture GetTexture(CardInfo.CardShape shape, int num)
    {
        Debug.Log(shape.ToString() + ", " + num);
        switch (shape)
        {
            case CardInfo.CardShape.Club:
                return club[num];
            case CardInfo.CardShape.Diamond:
                return diamond[num];
            case CardInfo.CardShape.Heart:
                return heart[num];
            case CardInfo.CardShape.Spade:
                return spade[num];
        }
        return blank;
    }
}
