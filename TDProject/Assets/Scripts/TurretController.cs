using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private bool isLinked;
    private float dragSpeed;
    private float distance = 0f;
    [Header("Stats")]
    public int damage = 10;
    public int range = 15;
    public float fireRate = 1f;
    public float fireCd = 0f;
    private float rotationSpeed = 15f;

    [Header("TargetingSys")]
    public Transform target;
    private float shortestDistance;
    public Transform cannonPoint;

    public GameObject bulletPrefab;
    public Transform baseRot;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0, 0.6f);
        isLinked = false;
        dragSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLinked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
            return;
            /*
            Debug.Log(Input.mousePosition);
            transform.Translate( Input.mousePosition *dragSpeed*Time.deltaTime);
            return;*/
        }
        if (target == null) return;
        #region Rotation
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 turretRotation = Quaternion.Lerp(baseRot.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        baseRot.rotation = Quaternion.Euler(turretRotation.x, turretRotation.y, 0f);
        #endregion

        if (fireCd > 1)
        {
            Shoot();
            fireCd = 0;
        }
        else
        {
            fireCd +=Time.deltaTime*  fireRate ;
        }
       

    }
    private void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {

            float distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);

            if (shortestDistance > distanceToTarget)
            {
                shortestDistance = distanceToTarget;
                nearestEnemy = enemy;
            }
        }
       
        if(nearestEnemy!=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Shoot()
    {
        GameObject bulletGO= Instantiate(bulletPrefab, cannonPoint.position - cannonPoint.forward, transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    #region    Drag&Drop

    private void OnMouseDown()
    {
        //Debug.Log("linked");
        isLinked = true;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }
    private void OnMouseUp()
    {
        isLinked = false;
    }
    #endregion
}
