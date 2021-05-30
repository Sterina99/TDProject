using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTurret : MonoBehaviour
{
    TurretController turretController;
    [SerializeField] bool isEmpty;
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
        turretController = other.GetComponent<TurretController>();
        if (turretController == null) return;
        Debug.Log("entered");
        if (turretController.isLinked && isEmpty)
        {
       //     Debug.Log("Snapped");
            turretController.gameObject.transform.position = gameObject.transform.position + Vector3.up *0.6f;
            isEmpty = false;
            turretController.isLinked = false;
            turretController.isOff = false;
        //    turretController
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Turret")) return;
        if (!isEmpty && other.gameObject==turretController.gameObject)
        {
            isEmpty = true;
            
        }
    }
}
