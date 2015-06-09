using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NumAnimation : MonoBehaviour {
    public int curNum,targetNum,deltaNum;
    public float MaxDuration;
    bool playing=false;
    int changePerDt;
    Text text_num;
	// Use this for initialization
	void Start () {
        curNum = 0;
        text_num = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            OnPlaying();
        }
	}
    void Reset()
    {
        curNum = 0;
    }
    public void OnPlaying()
    {
        curNum += changePerDt;
        
        if (curNum >= targetNum)
        {
            curNum = targetNum;
            OnFinish();
        }
        text_num.text = curNum.ToString();
    }
    public void OnFinish()
    {
        playing = false;
    }
    public void Play(int Num)
    {
        deltaNum = Num - curNum;
        targetNum = Num;
        if (deltaNum <= 0)
            return;
        if (deltaNum * Time.deltaTime > MaxDuration)
            changePerDt = (int)(deltaNum * Time.deltaTime / MaxDuration)+1;
        else
            changePerDt = 1;
        playing = true;
    }
}
