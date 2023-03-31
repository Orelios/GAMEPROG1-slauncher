using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(PlayerPrefs.GetInt("ranOnce") == 0)
        {
            PlayerPrefs.SetInt("savedSc4", 0); //reset
            PlayerPrefs.SetInt("ranOnce", 1);
        }
        //PlayerPrefs.SetInt("ranOnce", 1);
    }
}

/*
public class PlayerPrefsReset
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After scene is loaded and game is running");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        Debug.Log("SecondMethod After scene is loaded and game is running.");
    }
}
*/
