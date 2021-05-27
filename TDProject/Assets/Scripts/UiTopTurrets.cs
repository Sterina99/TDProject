using UnityEngine;
using UnityEngine.UI;

public class UiTopTurrets : MonoBehaviour
{
    public Button[] turretSpawners;
    public Button[] turretSnatchers;
    public GameObject[] turrets;
    public string[] name= {"TurretY", "TurretR", "TurretB", "TurretG"};
    private void Start()
    {
        for(int i=0; i < 4; i++)
        {
            turrets[i] = GameObject.Find( name[i]);
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

        //call function to have spawned turret follow mouse position and place it on click
    }


}
