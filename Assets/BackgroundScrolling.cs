using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {

	// Use this for initialization
    public float speed;
    private float offset;
	void Start () {
        offset = 0;
	}
	
	// Update is called once per frame
	void Update () {
        offset = offset + speed * Time.deltaTime;
        gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(offset, 0);
	
	}
}
