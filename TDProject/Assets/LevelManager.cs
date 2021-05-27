using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    EnemySpawner spawner;
   
    [Header("LevelManager")]
    [SerializeField] int level=2;
    [SerializeField] int prevLvl=0;
    public int enemyCounter=8;
    [SerializeField] float timer;
    public int difficultyFac=0;
    private float maxTime=10;
    private float currentTime=0;
    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        NewLevel();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCounter == 0)
        {
            Debug.Log("YOU WIN");
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

        spawner.Spawn(0.5f *(1-(level*0.006f)));
    }

    #endregion
}
