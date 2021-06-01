using UnityEngine;
using UnityEngine.UI;

public class UiTopTurrets : MonoBehaviour
{
    public Button[] turretSpawners;
    public Button[] turretSnatchers;
    public GameObject[] turrets;
    public Button[] upgradeArrows;
    public Text[] upgradeAmount;
    [SerializeField] Text[] turretLvl;
    public string[] naturretId = {"TurretY", "TurretR", "TurretB", "TurretG"};

    public Text baseText;
    public Text resText;
    [SerializeField] LevelManager lvlManager;

    private void Start()
    {
        for(int i = 0; i < naturretId.Length; i++)
        {
            turrets[i] = GameObject.Find(naturretId[i]);
        }
        lvlManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
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
        resText.text = "x " + value;
        
        CheckUpgrade();
    }

    private void CheckUpgrade ()
    {
       
            for (int i = 0; i < upgradeArrows.Length; i++)
            {
                 
                        if (turrets[i].GetComponent<TurretController>().lvlUpCost <= lvlManager.money && !turrets[i].GetComponent<TurretController>().isOff) //check if the turret is actuallyupgradable
                        {
                Debug.Log(i);
                          turretLvl[i].text = turrets[i].GetComponent<TurretController>().level.ToString();
                            upgradeArrows[i].gameObject.SetActive(true);
                            upgradeAmount[i].text= "Cost:\n x" + turrets[i].GetComponent<TurretController>().lvlUpCost;
                            upgradeAmount[i].gameObject.SetActive(true);
                            
                               EventHandler.current.UpgradePossible();
                        }
                          else if(turrets[i].GetComponent<TurretController>().lvlUpCost > lvlManager.money || turrets[i].GetComponent<TurretController>().isOff)
                          {
                            upgradeArrows[i].gameObject.SetActive(false);
                            upgradeAmount[i].gameObject.SetActive(false);
                          }
                
        }
        
    }

    public void UpgradeTurret (int turretId) //identification can be changed or use the turrets[] array dependent on the needs
    {
      //  Debug.Log("UPgrade");
        //do the upgrade
        //mak sure turret upgradability is changed if neccessary
        TurretController currentTurret = turrets[turretId].GetComponent<TurretController>();
        currentTurret.LevelUp();
        lvlManager.money -= currentTurret.lvlUpCost;
        currentTurret.lvlUpCost += 3;
        OnResourcePicked(lvlManager.money);
       
    }
}
