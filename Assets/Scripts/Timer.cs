using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    public GameObject flagObject;
    public MainMenu gameManager;
    public Flag flag;
    public bool timeRecord = true;
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
        
            
        
       
	}
	
	// Update is called once per frame
	void Update () {

        if (gameManager.gameStart && gameManager.gameOver == false)
        {
            if (timeRecord)
            {
                startTime = Time.time;
                timeRecord = false;
            }
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f1");

            if (t >= 0)
                timerText.text = minutes + ":" + seconds;
        }

	}
}
