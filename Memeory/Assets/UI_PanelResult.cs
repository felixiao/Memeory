using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_PanelResult : MonoBehaviour {
    public GameObject panel_result;
    public GameObject text_successNum, text_failedNum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ShowResult(int successNum,int failedNum)
    {
        panel_result.SetActive(true);
        text_successNum.GetComponent<NumAnimation>().Play(successNum);
        text_failedNum.GetComponent<NumAnimation>().Play(failedNum);
    }

}
