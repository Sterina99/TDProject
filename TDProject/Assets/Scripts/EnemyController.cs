using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    Transform target;
    LevelManager sceneManager;
    [SerializeField] int health;
    [SerializeField] GameObject partycleEffect;
    public int damage;
    public int money;
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Goal").transform;
        SetDestinationToTarget();
        sceneManager = FindObjectOfType<LevelManager>();
        #region Stats
        health = 100;
        damage = 10;
        money = 3;
        #endregion
    }

    void Update()
    {
      
    }
  
    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            myNavMeshAgent.SetDestination(hit.point);
        }
    }
    void SetDestinationToTarget()
    {
        myNavMeshAgent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            sceneManager.enemyCounter--;

          //  Debug.Log(other.GetComponent<Bullet>().damage);
            health -= other.GetComponent<Bullet>().damage;
            if (health <= 0)
            {
                GameObject instance = Instantiate(partycleEffect,transform.position,transform.rotation);

                Destroy(instance, 2f);
                gameObject.SetActive(false);
                sceneManager.addMoney(money);

            }

        }
    }
}
