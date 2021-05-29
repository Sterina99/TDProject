using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    LevelManager levelManager;
    int value;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        value = Random.Range(1, 5);
   //     anim = GetComponent<Animator>();
    //    anim.Play("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {

        Destroy(gameObject);
        levelManager.addMoney(value);
    }
}
