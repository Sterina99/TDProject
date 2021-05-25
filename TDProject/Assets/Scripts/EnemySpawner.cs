using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    // 0 Sphere 1 Cylinder
    [SerializeField] GameObject [] enemyPrefabs;
    private List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();   
        SetEnemies(8);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }

    private void Spawn()
    {
        
            StartCoroutine(RespawnTimer());
        
    }
    IEnumerator RespawnTimer()
    {
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeInHierarchy)
                enemy.SetActive(true);
            yield return new WaitForSeconds(3f);
        }
           

    }
    private void SetEnemies(int level)
    {
        for (int i=0; i<level; i++)
        {
            GameObject currentPrefab = Instantiate(enemyPrefabs[Random.Range(0,2)].gameObject);
            currentPrefab.transform.position = transform.position;
            currentPrefab.SetActive(false);
            enemies.Add(currentPrefab);
        }

    }
}
