using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Camera[] cameras;
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadSceneAsync("UI testscene", LoadSceneMode.Additive);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  stopTime()
    {
        Debug.Log("STOP");
        Time.timeScale = 0f;
    }
}
