using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventHandler : MonoBehaviour
{

    public static EventHandler current;

    public static EventHandler Current()
    {
        return current;
    }
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }


    public event Action OnRepairNeeded;

    public void RepairNeeded()
    {
        if (OnRepairNeeded != null)
        {
            OnRepairNeeded();
        }
    }public event Action OnUpgradePossible;

    public void UpgradePossible()
    {
        if (OnUpgradePossible != null)
        {
            OnUpgradePossible();
        }
    }
}
