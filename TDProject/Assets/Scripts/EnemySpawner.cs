using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    // 0 Sphere 1 Cylinder
    [SerializeField] GameObject [] enemyPrefabs;
    private List<GameObject> enemies;
    public float spawnTime;
    // Start is called before the first frame update
    void Awake()
    {
        enemies = new List<GameObject>();   
       
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    #region SpawnMechanic
    public void Spawn(float timer)
    {
        StopAllCoroutines();
      //  Debug.Log("Spawn");
        spawnTime = timer;
        StartCoroutine(RespawnTimer());
        
    }
    IEnumerator RespawnTimer()
    {
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                enemy.transform.position = transform.position;
            }
               
            yield return new WaitForSeconds(spawnTime);
        }
           

    }
    public void SetEnemies(int level)
    {
        for (int i=0; i<level; i++)
        {
            GameObject currentPrefab = Instantiate(enemyPrefabs[Random.Range(0,2)].gameObject);
            currentPrefab.transform.position = transform.position;
            currentPrefab.SetActive(false);
            enemies.Add(currentPrefab);
        }
        
    }
    #endregion

   
}

