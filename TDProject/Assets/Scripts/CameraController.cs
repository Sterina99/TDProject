using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float camSpeed;
    private float boardThickness;
    // Start is called before the first frame update
    void Start()
    {
        camSpeed = 10f;
        boardThickness = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x < boardThickness)
        {
            transform.Translate(camSpeed * Time.deltaTime * Vector3.left, Space.World);
        }
        if(Input.mousePosition.x > Screen.width -boardThickness)
        {
            transform.Translate(camSpeed * Time.deltaTime * Vector3.right, Space.World);
        }
        if(Input.mousePosition.y < boardThickness)
        {
            transform.Translate(camSpeed * Time.deltaTime * Vector3.back, Space.World);
        }
        if(Input.mousePosition.y > Screen.height-boardThickness)
        {
            transform.Translate(camSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }
    }
}
