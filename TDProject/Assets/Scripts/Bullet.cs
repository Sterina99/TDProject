using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed=80f;
    public int damage=30;
    // Start is called before the first frame update
    public void Seek (Transform _target)
    {
        target = _target;
    }
    private void Start()
    {
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;

        //Basic way of detecting collision (?) 
        float distanceThisFrame = speed * Time.deltaTime;

        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

   
    
}
