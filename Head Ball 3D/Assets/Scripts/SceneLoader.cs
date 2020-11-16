using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        LoadSavedScene();
    }
    
    private void LoadSavedScene()
    {
        //PlayerPrefs.GetInt("SAVED_LEVEL");
        if (!(PlayerPrefs.GetInt("SAVED_LEVEL") == 0))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SAVED_LEVEL"));
        }
        
        else
        {
            PlayerPrefs.SetInt("SAVED_LEVEL", 1); 
            SceneManager.LoadScene(PlayerPrefs.GetInt("SAVED_LEVEL"));
        }
    }

}
