using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    Transform target;
    SceneManager sceneManager;
    [SerializeField] int health;
    [SerializeField] GameObject partycleEffect;
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Goal").transform;
        SetDestinationToTarget();
        sceneManager = FindObjectOfType<SceneManager>();
        health = 100;
        
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
            Destroy(other.gameObject);
           sceneManager.enemyCounter--;
            Debug.Log(other.GetComponent<Bullet>().damage);
            health -= other.GetComponent<Bullet>().damage;
            if (health <= 0)
            {
                GameObject instance = Instantiate(partycleEffect,transform.position,transform.rotation);

                Destroy(instance, 2f);
                gameObject.SetActive(false);
            }

        }
    }
}