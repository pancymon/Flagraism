using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    

    public GameObject Play;
    public GameObject Help;
    public GameObject helpContent;
    public TimesofGame timesofGame;
    
    public Flag flag;
    public Camera MainCamera;
    public Vector3 camerOriginalPoint = new Vector3(0, 3.5f, -10);
    public Vector3 gameStartPoint = new Vector3(0, 1.35f, -10);
    public bool gameStart = false;
    public bool moveCamera = false;
    public bool gameOver = false;
    
    
    public float speed = 0.5f;

    public GameObject m_Hero;

    public void moveObjects()
    {      
        flag.transform.position = new Vector3(6.868f, -0.8f, 0);
        if(timesofGame.isFirstTime)
            moveCamera = true;
    }



    public void GetHelp()
    {
        helpContent.SetActive(true);
    }

    void Start()
    {
        GameObject gameObject = GameObject.FindWithTag("TimesofGame");
        if (gameObject != null)
        {
            timesofGame = gameObject.GetComponent<TimesofGame>();

        }
        if (flag == null)
        {
            Debug.Log("Cannot find 'TimesofGame' script");
        }

        if (!timesofGame.isFirstTime)
        {
            MainCamera.transform.position = gameStartPoint;
            flag.transform.position = new Vector3(6.868f, -0.8f, 0);
        }

        if (!timesofGame.isFirstTime)
        {
            Play.SetActive(false);
            Help.SetActive(false);
        }
        helpContent.SetActive(false);
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


        if (MainCamera.transform.position.y <= gameStartPoint.y)
        {
            if (m_Hero != null)
                m_Hero.SendMessage("GameStart");
            gameStart = true;
            moveCamera = false;
            timesofGame.isFirstTime = false;
        }


        if (gameOver)
        {
            Play.SetActive(true);
            Help.SetActive(true);
        }

    }

    public void ResetGame()
    {
        gameOver = false;
        
        if(!timesofGame.isFirstTime)
            Application.LoadLevel(0);
    }

}
