using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalManager : MonoBehaviour
{
    public int health = 100;
    [SerializeField] Slider slider;
    LevelManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("HPBar").GetComponent<Slider>();
        sceneManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= collision.gameObject.GetComponent<EnemyController>().damage;
            slider.value = ((float)health) / 100f;
            if (health <= 0)
            {
                EventHandler.current.EndGame();
            }
            sceneManager.enemyCounter--;
            collision.gameObject.SetActive(false);
        }
    }
}
