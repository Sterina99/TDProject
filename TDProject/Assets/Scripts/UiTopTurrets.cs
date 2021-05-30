using UnityEngine;
using UnityEngine.UI;

public class UiTopTurrets : MonoBehaviour
{
    public Button[] turretSpawners;
    public Button[] turretSnatchers;
    public GameObject[] turrets;
    public Button[] upgradeArrows;
    public string[] naturretId = {"TurretY", "TurretR", "TurretB", "TurretG"};

    public Text baseText;
    public Text resText;

    private void Start()
    {
        for(int i = 0; i < naturretId.Length; i++)
        {
            turrets[i] = GameObject.Find(naturretId[i]);
        }
        
    }

    public void SnatchTurret (int turretNumber)
    {
        turrets[turretNumber].gameObject.SetActive(false);
        turretSnatchers[turretNumber].gameObject.SetActive(false);
        turretSpawners[turretNumber].gameObject.SetActive(true);
    }

    public void TurretSpawner (int turretNumber)
    {
        turrets[turretNumber].gameObject.SetActive(true);
        turretSnatchers[turretNumber].gameObject.SetActive(true);
        turretSpawners[turretNumber].gameObject.SetActive(false);

        turrets[turretNumber].GetComponent<TurretController>().TurretSnatch();

        //call function to have spawned turret follow mouse position and place it on click
        
    }

    public void OnBaseHit ()
    {
        baseText.text = "Base health: " + "health value"/*need the actual variable instead*/;
    }

    public void OnResourcePicked (int value)
    {
        resText.text = "" + value;
        CheckUpgrade();
    }

    private void CheckUpgrade ()
    {
        if (true) //check the resources and if they are sufficient to upgrade
        {
            for (int i = 0; i < upgradeArrows.Length; i++)
            {
                if (true) //check if the turret is actuallyupgradable
                {
                    upgradeArrows[i].gameObject.SetActive(true);
                }
            }
        }
    }

    public void UpgradeTurret (string turretId) //identification can be changed or use the turrets[] array dependent on the needs
    {
        //do the upgrade
        //mak sure turret upgradability is changed if neccessary
        CheckUpgrade();
    }
}
