using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    List<GameObject> bullets;
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject NewBullet(Transform firePoint)
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position-firePoint.forward, firePoint.rotation);
        bullets.Add(newBullet);
        return newBullet;
    }
    //needs the position from where to spawn the bullet
    public GameObject GetBullet(Transform firePoint) {


        GameObject currentBullet=null;
        if (bullets.Count == 0) return NewBullet(firePoint);
        foreach(GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = firePoint.position;
                bullet.SetActive(true);

                currentBullet = bullet;
            }
        }
        if (currentBullet == null) return NewBullet(firePoint);
        return currentBullet;    
    }
}
