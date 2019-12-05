using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System;

public class SavePlayerCurrentScene : MonoBehaviour {

    public string scene;
    public Scene myCurrentScene;

    private void Start()
    {                
        Debug.Log("beggin in: " + myCurrentScene.name);       
    }
    
    void Update ()
    {
        myCurrentScene = SceneManager.GetActiveScene();
        scene = myCurrentScene.name.ToString();
        Debug.Log("Current scene: " + scene);       
    }
    
    private void OnApplicationQuit()
    {
        //In Unity Editor
        int myScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene when exit: " + myScene);     
        PlayerPrefs.SetInt("SavedScene", myScene);                        
    }
 
    private void OnApplicationPause()
    {
        //In Android
        int myScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene when exit: " + myScene);      
        PlayerPrefs.SetInt("SavedScene", myScene);
    }
}
