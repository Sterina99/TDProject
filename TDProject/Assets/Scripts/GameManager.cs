using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instace;
    public static GameManager Instance
    {
        get
        {
            return instace;
        }
    }
    //[SerializeField] Camera[] cameras;
    [SerializeField] GameObject endCover;
    // Start is called before the first frame update
    void Awake()
    {
        if (instace != null && instace != this) Destroy(this);
        if (instace == null) instace = this;
        SceneManager.LoadScene("UI testscene", LoadSceneMode.Additive);

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        StartCoroutine(SetRightScene(0));
    }

    private void Start()
    {

        EventHandler.current.OnEndGame += EndGame;

    }
    // Update is called once per frame
    void Update()
    {
    }

    public void stopTime()
    {
        //  Debug.Log("STOP");
        Time.timeScale = 0f;
    }
    public void EndGame()
    {
        endCover = GameObject.Find("EndCoverTracker").transform.Find("End Cover").gameObject;
        endCover.gameObject.SetActive(true);
        stopTime();

    }
    public void RestartGame()
    {
        SceneManager.UnloadSceneAsync("UI testscene");
        SceneManager.UnloadSceneAsync("SampleScene");
        StartCoroutine(LoadScenes(0));
    }
    /* private void LoadScenes()
     {
         SceneManager.LoadSceneAsync("UI testscene", LoadSceneMode.Additive);
         SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive);

         Time.timeScale = 0f;
     }*/
    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator LoadScenes(int sceneIndex)
    {
        yield return new WaitForEndOfFrame();

        SceneManager.LoadScene("UI testscene", LoadSceneMode.Additive);


        yield return null;

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

        yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneAt(sceneIndex));
        Time.timeScale = 0f;
    }
    private IEnumerator SetRightScene(int sceneIndex)
    {
        yield return new WaitForEndOfFrame();
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(sceneIndex));
        Time.timeScale = 0f;
    }
}
