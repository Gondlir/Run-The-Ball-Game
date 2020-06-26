using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [SerializeField] private Slider sliderLoader;
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject sliderGameObject;
    public int sceneToLoad { get; set; }
    public static Manager instance;

    void Awake() 
    {
        sliderGameObject.SetActive(true);
        mainMenuPanel.SetActive(true);
        startPanel.SetActive(false);
    }
    void Start() 
    {
        StartCoroutine(Await());
        //transitionAnimator.Play("CrossfadeEnd");
        transitionAnimator.SetTrigger("Start");
    }

    public void LastScene()
    {
        sceneToLoad = PlayerPrefs.GetInt("SavedScene");
        if (sceneToLoad == 0)
        {
            //SceneManager.LoadSceneAsync("Level1");
            StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex + 1));           
        }
        else if (sceneToLoad != 0)
        {
            //SceneManager.LoadScene(sceneToLoad);
            //StartCoroutine(TransitionScenes(sceneToLoad));
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
                transitionAnimator.SetTrigger("Start");
                yield return null;
         }
    }
    public IEnumerator Await() 
    {
        yield return new WaitForSeconds(3f);
        LastScene();
    }
}
