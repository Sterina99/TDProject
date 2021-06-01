using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitHandler : MonoBehaviour
{
    Button restart;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        restart = GetComponent<Button>();
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        restart.onClick.AddListener(gameManager.QuitGame);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
