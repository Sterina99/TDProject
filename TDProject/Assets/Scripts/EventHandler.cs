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
    public event Action OnScoreUpdate;

    public void UpdateScore()
    {
        if (OnScoreUpdate != null)
        {
            OnScoreUpdate();
        }
    }
    public event Action OnEndGame;

    public void EndGame()
    {

        if (OnEndGame!=null)
        {
            OnEndGame();
        }
    }

    public event Action OnEnemyPowerUp;

    public void EnemyPowerUp()
    {
        if (OnEnemyPowerUp != null)
        {
            OnEnemyPowerUp();
        }
    }
}
