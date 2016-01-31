using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger enter!");
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Debug.Log("collision");
        collision2D.transform.root.SendMessage("setGameOver", 1);
    }
}
