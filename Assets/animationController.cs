using UnityEngine;
using System.Collections;

public class animationController : MonoBehaviour {

    HeroControl hero_;
    Animator anim;
    GameObject heroPre;

	// Use this for initialization
	void Start () {
        hero_ = GameObject.Find("Hero").GetComponent<HeroControl>();
        heroPre = GameObject.Find("Hero");
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	if(hero_.m_GameOver)
    {
        anim.SetBool("GameOver", true);
    }

    if (anim.GetCurrentAnimatorStateInfo(0).IsName("killll"))
    {
        heroPre.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        heroPre.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        heroPre.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        heroPre.transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
	}
}
