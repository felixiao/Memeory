using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CardTouch : MonoBehaviour {
    RectTransform rectTrans;
    public Rect RectHit;
	// Use this for initialization
	void Start () {
        rectTrans = GetComponent<RectTransform>();
        RectHit = new Rect(transform.position.x - rectTrans.rect.width / 2, transform.position.y - rectTrans.rect.height / 2, transform.position.x + rectTrans.rect.width / 2, transform.position.y + rectTrans.rect.height / 2);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && HitTest(RectHit, Input.mousePosition))
        {
            Debug.Log("Hit " + this.name);
        }
        
	}
    public bool HitTest(Rect rect, Vector3 pos)
    {
        if (pos.x < rect.xMax && pos.x > rect.xMin && pos.y < rect.yMax && pos.y > rect.yMin)
        {
            return true;
        }
        return false;
    }
}
