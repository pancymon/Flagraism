using UnityEngine;
using System.Collections;

public class TimesofGame : MonoBehaviour {

    public bool isFirstTime = true;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
