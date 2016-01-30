using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    public GameObject flagObject;
    public Flag flag;
    private float startTime;

	// Use this for initialization
	void Start () {
        flagObject = GameObject.FindWithTag("Flag");
        if (flagObject != null)
        {
            flag = flagObject.GetComponent<Flag>();
            
        }
        if (flag == null)
        {
            Debug.Log("Cannot find 'Flag' script");
        }
        startTime =
            (flag.endPoint - flag.transform.position.y) / flag.speed;
        
       
	}
	
	// Update is called once per frame
	void Update () {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        if( t >= 0)
        timerText.text = minutes + ":" + seconds;

	}
}
