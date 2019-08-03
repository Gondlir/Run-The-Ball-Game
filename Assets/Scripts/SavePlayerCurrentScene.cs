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
        Debug.Log("iniciou cena em: " + myCurrentScene.name);       
    }
    
    void Update ()
    {
        myCurrentScene = SceneManager.GetActiveScene();
        scene = myCurrentScene.name.ToString();
        Debug.Log("Cena rodando é: " + scene);       
    }
    
    private void OnApplicationQuit()
    {
        //In Unity Editor
        int myScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Cena quando saiu é: " + myScene);     
        PlayerPrefs.SetInt("SavedScene", myScene);                        
    }
 
    private void OnApplicationPause()
    {
        //In Android
        int myScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Cena quando saiu é: " + myScene);      
        PlayerPrefs.SetInt("SavedScene", myScene);
    }
}
