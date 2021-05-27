using UnityEngine;
using UnityEngine.UI;

public class UiTopTurrets : MonoBehaviour
{
    public Image turretImage;
    private bool turretHere = false;
    private bool turretIsBeingMoved = false;
    private GameObject turret;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("It collided");

        if (collision.tag == "Turret")
        {
            collision.gameObject.SetActive(false);
            turretImage.gameObject.SetActive(true);
            turretHere = true;
            turret = collision.gameObject;
        }
    }

    private void OnMouseDown()
    {
        if (turretHere == false)
        {
            return;
        }

        else
        {

            turretImage.gameObject.SetActive(false);
            turretHere = false;
            turret.gameObject.SetActive(true);
        }
    }
}
