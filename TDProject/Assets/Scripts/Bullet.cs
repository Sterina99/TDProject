using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed=80f;
    // Start is called before the first frame update
    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;

        //Basic way of detecting collision (?) 
        float distanceThisFrame = speed * Time.deltaTime;

        if(distanceThisFrame>= dir.magnitude)
        {
            Hit();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void Hit()
    {
        Debug.Log("Hit");
    }
}
