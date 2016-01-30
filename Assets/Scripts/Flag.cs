using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

    public float speed = 0.5f;
    public float endPoint = 4.8f;
    private float wholeTime;
    private float tour;

	// Use this for initialization
	void Start () {
        tour = endPoint - transform.position.y;
        wholeTime = tour / speed;
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.smoothDeltaTime, 0);

        pos += velocity;

        if (transform.position.y <= endPoint)
            transform.position = pos;

	}


}
