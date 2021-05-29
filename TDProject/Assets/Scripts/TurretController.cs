using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretController : MonoBehaviour
{
    public bool isLinked;
    private float dragSpeed;
    private float distance = 0f;

    UiTopTurrets uiTopTurrets;
    [SerializeField] Slider slider;
    [SerializeField] Button repairButton;

    [Header("Stats")]
    [SerializeField] int id;
    public int damage = 10;
    public int range = 15;
    public float fireRate = 1f;
    public float fireCd = 0f;
    private float rotationSpeed = 15f;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    

    [Header("TargetingSys")]
    public Transform target;
    private float shortestDistance;
    public Transform cannonPoint;

    public GameObject bulletPrefab;
    public  Transform baseRot;
    public Transform platForm;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0, 0.6f);
        isLinked = false;
        dragSpeed = 2f;

        maxHealth = 10f;
        health = maxHealth;
        repairButton= GetComponentInChildren<Button>();
        repairButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //when clicked on, link the turret position to the mouse's
        if(isLinked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x,3.5f,rayPoint.z);
            
            return;
            /*
            Debug.Log(Input.mousePosition);
            transform.Translate( Input.mousePosition *dragSpeed*Time.deltaTime);
            return;*/
        }
        health -= Time.deltaTime;
        slider.value = health / maxHealth;
        if(health<0)
        {
            //hide Hp bar and show Repair button
            slider.gameObject.SetActive(false);
            repairButton.gameObject.SetActive(true);
        }
        if (target == null) return;
        #region Rotation
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 turretRotation = Quaternion.Lerp(baseRot.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        baseRot.rotation = Quaternion.Euler(turretRotation.x, turretRotation.y, 0f);
        #endregion
        
        //turrets shot mechanic, with a CD
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
        TurretSnatch();
    }
    private void OnMouseUp()
    {
        isLinked = false;

    }
    public void TurretSnatch()
    {
        //Debug.Log("linked");
        isLinked = true;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    #endregion
   public void RepairTurret()
    {
        if (uiTopTurrets == null)
        {
            uiTopTurrets= GameObject.Find("Panel").GetComponent<UiTopTurrets>();
        }
        health = 10f;
        slider.gameObject.SetActive(true);
        repairButton.gameObject.SetActive(false);
        uiTopTurrets.SnatchTurret(id);

        
    }
    
}
