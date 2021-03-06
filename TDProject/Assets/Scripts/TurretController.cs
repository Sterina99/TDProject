using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretController : MonoBehaviour
{
    public bool isLinked;
    public bool isOff;
 //   private float dragSpeed;
    private float distance = 0f;
    [SerializeField] bool isPlaced;

    [Header("UI")]
   [SerializeField] UiTopTurrets uiTopTurrets;
    [SerializeField] Slider slider;
    [SerializeField] Button repairButton;

    [Header("Stats")]
    public int level = 1;
    [SerializeField] int id;
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCd = 0f;
    private float rotationSpeed = 15f;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    public int lvlUpCost;
    [SerializeField] int repairCost=5;
    

    [Header("TargetingSys")]
    public Transform target;
    private float shortestDistance;
    public Transform cannonPoint;

    [SerializeField] BulletPooling ammoSys;
    public  Transform baseRot;
    public Transform platForm;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0, 0.6f);
        isLinked = false;
        isOff = true;
        //  dragSpeed = 2f;
        lvlUpCost = 8;
        repairCost = 8;
        maxHealth = 15f;
        health = maxHealth;
        repairButton= GetComponentInChildren<Button>();
        repairButton.gameObject.SetActive(false);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
     
            uiTopTurrets = GameObject.Find("Panel").GetComponent<UiTopTurrets>();
      
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
        if (target == null || isOff) return;
       
        
        if(health<0)
        {
            EventHandler.current.RepairNeeded();
            //hide Hp bar and show Repair button
            slider.gameObject.SetActive(false);
            repairButton.gameObject.SetActive(true);
            Debug.Log("dead");
            isOff = true;
            uiTopTurrets.OnResourcePicked(levelManager.money);
        }
        
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
            health -= 1;
            slider.value = health / maxHealth;
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
        //scan the closest target
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

        GameObject bulletGo = ammoSys.GetBullet(cannonPoint);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
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
        if (levelManager.money < repairCost) return;
        levelManager.money -= repairCost;
        uiTopTurrets.OnResourcePicked(levelManager.money);
       // if (uiTopTurrets == null)
  //      {
   //         uiTopTurrets= GameObject.Find("Panel").GetComponent<UiTopTurrets>();
    //    }
        //refresh the UI element
        health = maxHealth;
        slider.value = health / maxHealth;

        slider.gameObject.SetActive(true);
        repairButton.gameObject.SetActive(false);
        uiTopTurrets.SnatchTurret(id);
        isOff = false;
        EventHandler.current.UpdateScore();


    }
    
    public void LevelUp()
    {
        EventHandler.current.UpdateScore();
      //  Debug.Log("LevelUP");
        level++;
        fireRate = fireRate * 1.2f;
        range = range * 1.2f;
        maxHealth = maxHealth * 1.2f;
        //refresh the UI element
        health = maxHealth;
        slider.value = health / maxHealth;

    }
}
