using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public AudioSource audioBackground;
    public Image imgOn;
    public Image imgOff;
    public Slider sliderLoader;
    public static Manager instance;
    int sceneToLoad;
    void Start() 
    {
        LastScene();
    }
    public void Stop()
    {
        if (audioBackground.isPlaying)
        {
            audioBackground.Pause();
            imgOn.enabled = false;
            imgOff.enabled = true;
            
        }
        else
        {
            audioBackground.Play();
            imgOn.enabled = true;
            imgOff.enabled = false;
        }      
    }

    public void LastScene()
    {
        sceneToLoad = PlayerPrefs.GetInt("SavedScene");
        if (sceneToLoad == 0)
        {
            SceneManager.LoadSceneAsync("Level1");
        }
        else if (sceneToLoad != 0)
        {
            //SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(LoadAsync(sceneToLoad));
        }
    }       
        public IEnumerator LoadAsync(int sceneIndex) 
        {
            AsyncOperation operatoin = SceneManager.LoadSceneAsync(sceneIndex);
            operatoin.allowSceneActivation = false;
            while (!operatoin.isDone) 
            {
                float progress = Mathf.Clamp01(operatoin.progress / .9f);         
                sliderLoader.value = progress;
                operatoin.allowSceneActivation = true;
                yield return null;
            }
        }
        
    }
