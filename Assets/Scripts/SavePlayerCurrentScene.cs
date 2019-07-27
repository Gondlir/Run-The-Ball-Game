using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerCurrentScene : MonoBehaviour {

    string scene;
    Scene myCurrentScene;

    private void Start()
    {
                
        Debug.Log("iniciou cena em: " + scene);       
    }
    
    void Update ()
    {
        myCurrentScene = SceneManager.GetActiveScene();
        scene = myCurrentScene.name;

        Debug.Log("Cena rodando é: " + scene);
        //PlayerPrefs.GetString(scene);
        // PlayerPrefs.Save();
    }
    private void OnApplicationQuit()
    {       
        SceneManager.GetSceneByName(scene);
        Debug.Log("Cena quando saiu é: " + scene);
        PlayerPrefs.GetString(scene);      
    }
     
}
