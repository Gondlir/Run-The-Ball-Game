using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class Levels : MonoBehaviour {

    public static Levels myLevel;
    public GameObject nextPanel;
    public GameObject deadPanel;
    public GameObject startPanel;
    public GameObject exitButton;

    public bool startGame = false; 
      
    private Scene myScenes;
    string scene;
    int sceneToLoad;
    void Start()
    {      
        Levels.myLevel = this;
    }  
    public void ConfiButton()
    {
        Time.timeScale = 0;
        exitButton.SetActive(true);                  
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void StartGame()
    {
        startGame = true;
        startPanel.SetActive(false);
    }   
    public void LastScene()
    {
        //Menu Button "Play"
        //If the player has already played and left, loads the scene in which he left. If the player never played loads the first scene
        sceneToLoad = PlayerPrefs.GetInt("SavedScene");
        if (sceneToLoad == 0)
            SceneManager.LoadScene("Level1");
        else if (sceneToLoad != 0)
            SceneManager.LoadScene(sceneToLoad);             
    }
    public void NextScene()
    {
        //Load the next scene in the build settings. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        deadPanel.SetActive(false);
    }
    public void ReloadScene()
    {
        //Reload the current scene that player was
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    } 
    
   public IEnumerator Reload ()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("Reload");
    }
    public void FacebookLike()
    {
        Application.OpenURL("https://www.facebook.com/gamelandstudio");
    }
    public void RateTheApp()
    {
        Application.OpenURL("https://www.facebook.com/gamelandstudio");
    }
}
