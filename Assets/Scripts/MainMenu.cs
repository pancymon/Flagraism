using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button Play;
    public Button Help;
    public Texture2D helpImage;
    public Flag flag;
    public Camera MainCamera;
    public Vector3 camerOriginalPoint = new Vector3(0, 3.5f, -10);
    public Vector3 gameStartPoint = new Vector3(0, 1.35f, -10);
    public bool gameStart = false;
    public bool moveCamera = false;
    public bool gameOver = false;
    public bool onClickHelp = false;
    public float speed = 0.5f;

    public GameObject m_Hero;

    public void moveObjects()
    {      
        flag.transform.position = new Vector3(6.868f, -0.8f, 0);
        moveCamera = true;
    }

    public void HideButton()
    {
        Play.GetComponentInChildren<Image>().enabled = false;    
        Play.GetComponentInChildren<Text>().color = Color.clear;
        Play.enabled = false;
        Help.GetComponentInChildren<Image>().enabled = false;
        Help.GetComponentInChildren<Text>().color = Color.clear;
        Help.enabled = false;
    }

    public void GetHelp()
    {
        onClickHelp = true;
    }

    void OnGUI()
    {
        if(onClickHelp)
            GUI.DrawTexture(new Rect(Screen.width/4,Screen.height/4, Screen.width/2,Screen.height/2),helpImage);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (moveCamera)
        {
            
            Vector3 pos = MainCamera.transform.position;
            Vector3 velocity = new Vector3(0, speed * Time.smoothDeltaTime, 0);

            pos -= velocity;

            if (MainCamera.transform.position.y >= gameStartPoint.y)
            {
                MainCamera.transform.position = pos;
            }

        }


        if (MainCamera.transform.position.y <=  gameStartPoint.y)
        {
            if (m_Hero != null)
                m_Hero.SendMessage("GameStart");
            gameStart = true;
            moveCamera = false;
        }
    }
	


}
