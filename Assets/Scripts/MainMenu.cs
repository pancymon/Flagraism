using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button Play;
    public Button Quit;
    public Flag flag;
    public Camera MainCamera;
    public Vector3 gameStartPoint;
    public bool gameStart = false;
    
    public void moveObjects()
    {
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, new Vector3(0, 1.35f, -10), 2);
        
        flag.transform.position = new Vector3(6.868f, -0.8f, 0);
    }

    public void HideButton()
    {
        Play.GetComponentInChildren<Image>().enabled = false;    
        Play.GetComponentInChildren<Text>().color = Color.clear;
        Quit.GetComponentInChildren<Image>().enabled = false;
        Quit.GetComponentInChildren<Text>().color = Color.clear;
    }
	
    public void GameStart()
    {
        if (MainCamera.transform.position == gameStartPoint)
            gameStart = true;
    }

}
