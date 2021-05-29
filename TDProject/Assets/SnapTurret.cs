using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTurret : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TurretController turretController = other.GetComponent<TurretController>();
        if (turretController == null) return;
        Debug.Log("entered");
        if (turretController.isLinked)
        {
       //     Debug.Log("Snapped");
            turretController.gameObject.transform.position = gameObject.transform.position + Vector3.up *0.6f;
            turretController.isLinked = false;
        //    turretController
        }
    }
}
