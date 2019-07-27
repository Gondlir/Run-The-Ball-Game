using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class Levels : MonoBehaviour {

    public static Levels myLevel;
    public GameObject panel;
    public GameObject finish;
    public GameObject startPanel;
    public GameObject backgroundConfigImage;
    public GameObject exitButton;

    public bool startGame = false;

    private string storeId = "3062053";
    private string adVideo = "video";
    private string adBanner = "LevelComplete";
    private string rewardVid = "rewardedVideo";
    private int nextScene;

    void Start()
    {
        // Monetization.Initialize(storeId, true);
        //ShowVideoAd();
        Levels.myLevel = this;
    }
    /*
    public void ShowVideoAd()
    {
        if (Monetization.IsReady(adVideo))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(adVideo) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void ShowBannerAd()
    {
        if (Monetization.IsReady(adBanner))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(adBanner) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }
    }
    */
    public void ConfiButton()
    {
        Time.timeScale = 0;

        backgroundConfigImage.SetActive(true);
        exitButton.SetActive(true);
                     
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("saiu");
    }

    public void StartGame()
    {
        startGame = true;
        startPanel.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadScene()
    {
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
        Application.OpenURL("https://www.facebook.com/kaoe.silvaSK8");
    }
    public void RateTheApp()
    {
        Application.OpenURL("https://www.facebook.com/kaoe.silvaSK8");
    }
}
