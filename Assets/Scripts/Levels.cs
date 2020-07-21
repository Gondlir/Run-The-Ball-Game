using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Cinemachine;
public class Levels : MonoBehaviour {
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform endLinePosition;
    [SerializeField] private Slider sliderPlayerProgress;
    [SerializeField] private GameObject levelStartPanel;
    [SerializeField] private GameObject coinStartPanel;
    //[SerializeField] private Animator transitionAnimator;

    public GameObject currentStatusLevelAndCoinProgressPanel;
    public GameObject deadPanel;
    public GameObject startPanel;
    public GameObject exitButton;
    public GameObject nextPanel;
    public static Levels myLevel;
    
    public bool startGame { get; set; }
    public int sceneToLoad { get; set; }
    private float maxDistance;
    void Start()
    {
        //Time.timeScale = 0;
        //transitionAnimator.SetTrigger("FingerAnim");
        StartCoroutine(AwaitTransitionBegin());      
        Levels.myLevel = this;
        maxDistance = DistanceProgress();
        //startGame = true;
    }

    void Update() 
    {
        if (playerPosition.position.z <= maxDistance && playerPosition.position.z <= endLinePosition.position.z)
        {
            float distance = 1 - (DistanceProgress() / maxDistance);
            SetPlayerProgress(distance);
        }
    }
    float DistanceProgress()
    {
        return Vector3.Distance(playerPosition.position, endLinePosition.position);
    }

    void SetPlayerProgress(float progress)
    {
        sliderPlayerProgress.value = progress;
    }   
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void StartGame()
    {
        Time.timeScale = 1;      
        startGame = true;
        startPanel.SetActive(false);
        levelStartPanel.SetActive(false);
        coinStartPanel.SetActive(false);
        currentStatusLevelAndCoinProgressPanel.SetActive(true);
    }   
    public void LastScene()
    {
        //Menu Button "Play"
        //If the player has already played and left, loads the scene in which he left. If the player never played loads the first scene
        sceneToLoad = PlayerPrefs.GetInt("SavedScene");
        if (sceneToLoad == 0)
        {
            SceneManager.LoadScene("Level1");      
        }
        else if (sceneToLoad != 0) 
        {
            SceneManager.LoadScene(sceneToLoad);
        }
                       
    }
    public void NextScene()
    {
        //Load the next scene in the build settings.  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        deadPanel.SetActive(false);
        currentStatusLevelAndCoinProgressPanel.SetActive(true);
    }
    public void ReloadScene()
    {
        //Reload the current scene that player was
        currentStatusLevelAndCoinProgressPanel.SetActive(true);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    } 
    
   public IEnumerator AwaitTransitionBegin()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
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
