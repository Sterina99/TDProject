using UnityEngine;
using UnityEngine.UI;

public class UiTopTurrets : MonoBehaviour
{
    public Button[] turretSpawners;
    public Button[] turretSnatchers;
    public GameObject[] turrets;
    public string[] naturretId = {"TurretY", "TurretR", "TurretB", "TurretG"};
    public Text baseText;

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
}
