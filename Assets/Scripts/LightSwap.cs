using UnityEngine;
using System.Collections;

public class LightSwap : MonoBehaviour
{

    public float speed;
    private float angle;
    private float nextAngle;
    // Use this for initialization
    void Start()
    {
        //angle = GetComponent<Light>().spotAngle;
        angle = 20;
        nextAngle = Random.Range(20f, 40f);
    }

    // Update is called once per frame
    void Update()
    {
        if (angle > nextAngle)
        {
            angle -= speed*Time.deltaTime;
        }
        if (angle < nextAngle)
        {
            angle += speed * Time.deltaTime;
        }
        
            nextAngle = Random.Range(20f, 40f);
        
        GetComponent<Light>().spotAngle = angle;
    }
}
