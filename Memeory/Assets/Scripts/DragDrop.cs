using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DragDrop : MonoBehaviour {
    public Vector3 mousePos;
    public string rayName;
    bool b_touchEnds;
    public float deltaPosX,deltaPosY;//记录手指触碰纸牌时与纸牌中心的距离，以此保持触碰位置在手指移动中相对纸牌保持不变
    public Vector3 prePos;
    public Vector3 velocity;
    public float fraction;
    public Vector3 friction;
    public Vector3 screenPos;
	// Use this for initialization
	void Start () {
        velocity = Vector3.zero;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount >0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                mousePos = Input.mousePosition;
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                mousePos = Input.touches[0].position;
            }
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out rayHit, 100))
            {
                if (rayHit.transform == this.transform)
                {
                    rayName = rayHit.transform.name;
                    if (b_touchEnds)
                    {
                        deltaPosX = this.transform.position.x - rayHit.point.x;
                        deltaPosY = this.transform.position.y - rayHit.point.y;
                        b_touchEnds = false;
                    }
                    prePos = this.transform.position;
                    this.transform.position = new Vector3(rayHit.point.x + deltaPosX, rayHit.point.y + deltaPosY, 50);
                }
            }
        }else if (Input.GetMouseButtonUp(0) || Input.touchCount>0&&Input.touches[0].phase==TouchPhase.Ended)
        {
            b_touchEnds = true;
            velocity = new Vector3(this.transform.position.x - prePos.x, this.transform.position.y - prePos.y, 0);
            friction = velocity * fraction;

        }
        else
        {
            if (velocity.magnitude > 0.01)
            {
                prePos = this.transform.position;
                this.transform.position += velocity;
                velocity -= friction;
            }
            else
            {
                velocity = Vector3.zero;
            }
        }

        
        CheckScreenBoarder();
	}

    void CheckScreenBoarder()
    {
        screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.x > Screen.width || screenPos.y > Screen.height)
        {
            velocity = Vector3.zero;
            this.transform.position = prePos;
        }
    }
}
