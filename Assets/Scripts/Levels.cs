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

    public void ReinitializeLevel1 ()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        //ShowBannerAd();
    }

    public void Level2 ()
    {
        SceneManager.LoadSceneAsync("Level2");
        //ShowVideoAd();
    }

    public void Level3 ()
    {
        SceneManager.LoadSceneAsync("Level3");
        //ShowVideoAd();
    }
    public void Level4 ()
    {
        SceneManager.LoadSceneAsync("Level4");
        //ShowBannerAd(); ;
    }
    public void Level5 ()
    {
        SceneManager.LoadSceneAsync("Level5");       
    }
    public void Level6()
    {
        SceneManager.LoadSceneAsync("Level6");
    }
    public void Level7()
    {
        SceneManager.LoadSceneAsync("Level7");
    }
    public void Level8()
    {
        SceneManager.LoadSceneAsync("Level8");
    }
    public void Level9()
    {
        SceneManager.LoadSceneAsync("Level9");
    }
    public void Level10()
    {
        SceneManager.LoadSceneAsync("Level10");
    }
    /// <summary>
    ///  AQUI SE INICIA O CARREGAMENTO DAS PRÓXIMAS CENAS DO GAME 
    /// </summary>
    public void InitializeGame()
    {
        SceneManager.LoadScene("SampleScene");
        //ShowBannerAd(); ;
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Level2");
        //ShowBannerAd(); ;
    }

    public void NextLevel3()
    {
        SceneManager.LoadScene("Level3");
        //ShowVideoAd();
    }
    public void NextLevel4()
    {
        SceneManager.LoadScene("Level4");
        //ShowVideoAd();
    }
    public void NextLevel5()
    {
        SceneManager.LoadScene("Level5");      
    }
    public void NextLevel6()
    {
        SceneManager.LoadScene("Level6");      
    }
    public void NextLevel7()
    {
        SceneManager.LoadScene("Level7");      
    }
    public void NextLevel8()
    {
        SceneManager.LoadScene("Level8");      
    }
    public void NextLevel9()
    {
        SceneManager.LoadScene("Level9");      
    }
    public void NextLevel10()
    {
        SceneManager.LoadScene("Level10");      
    }
    public void Finished()
    {
        SceneManager.LoadScene("FinishGame");      
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
