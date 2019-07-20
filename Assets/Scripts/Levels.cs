using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public class Levels : MonoBehaviour {
    
    public static Levels myLevel;
    public GameObject panel;
    public GameObject finish;
    public GameObject startPanel;
    public bool startGame = false;

    private string storeId = "3062053";
    private string adVideo = "video";
    private string adBanner = "LevelComplete";
    private string rewardVid = "rewardedVideo";
    
	void Start ()
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
    public void StartGame ()
    {
        startGame = true;
       startPanel.SetActive(false);
    }
    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void LoadMyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
