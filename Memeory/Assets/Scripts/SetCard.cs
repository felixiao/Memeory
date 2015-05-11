using UnityEngine;
using System.Collections;

public class SetCard : MonoBehaviour {
    public enum CardShape
    {
        Heart,
        Diamond,
        Club,
        Spade
    }

    public CardShape shape;
    public int num;
    Material frontMat;
    TextureResource textRes;
	// Use this for initialization
	void Start () {
        frontMat = this.transform.GetChild(1).GetComponent<Renderer>().material;
        textRes = Camera.main.GetComponent<TextureResource>();
        SetCardContent(shape, num);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void SetCardContent(CardShape shape, int num)
    {
        frontMat.mainTexture = textRes.GetTexture(shape,num);
    }
}
