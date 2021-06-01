using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    EnemySpawner spawner;
    public int money;

    [Header("LevelManager")]
    [SerializeField] int level=1;
    [SerializeField] int prevLvl=0;
    public int enemyCounter=8;
    [SerializeField] float easef;
    public float difficultyFac=0;
    private int prevHealth = 100;
    bool poweredUp = false;
   // private float maxTime=10;
    [SerializeField] UiTopTurrets coinCount;
    [SerializeField] GoalManager goalManager;
   //private float currentTime=0;
    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        NewLevel();
        money = 0;
        coinCount= GameObject.Find("Panel").GetComponent<UiTopTurrets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter <= 0)
        {
            //   Debug.Log("YOU WIN");
          
            difficultyFac += (prevHealth/goalManager.health + 0.6f)* 2;
            //OTHER EASE FUNCTION
            // (1 - (1 - easef) * (easef * easef) + (easef) * (1 - (1 - easef) * (1 - easef)) 
            prevLvl = level;
            level +=  Mathf.RoundToInt( difficultyFac);
            if (level > 70 && !poweredUp)
            {
                poweredUp = true;
                EventHandler.current.EnemyPowerUp();
            }
         //   maxTime = 3 * level;
            NewLevel();
        }
        
        
    }
    #region LevelManagement
    private void NewLevel()
    {
        
        spawner.SetEnemies(level-prevLvl);
        enemyCounter = level;

        spawner.Spawn(0.4f);
    }

    #endregion

    public void addMoney(int val)
    {
        money += val;
        coinCount.OnResourcePicked(money);
    }

}
