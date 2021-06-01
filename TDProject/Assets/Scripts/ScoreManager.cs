using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        EventHandler.current.OnScoreUpdate += AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddScore()
    {
        score += 5;

        scoreText.text = "Score: \n" + score;
    }

}
