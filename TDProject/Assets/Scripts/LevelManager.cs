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
    [SerializeField] float timer;
    public int difficultyFac=0;
    private float maxTime=10;
    [SerializeField] UiTopTurrets coinCount;
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
            timer = 0;

            difficultyFac = (int)((maxTime - timer) / maxTime) *4;
            prevLvl = level;
            level +=  difficultyFac;
            NewLevel();
        }
        timer += Time.deltaTime;
        
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
