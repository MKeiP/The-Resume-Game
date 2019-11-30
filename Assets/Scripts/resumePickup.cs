using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumePickup : MonoBehaviour
{
    //Player playerScript;
    private GameObject showResume;
    private void Start()
    {
        //playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        showResume = GameObject.FindGameObjectWithTag("Resume");
        if (collision.tag == "Player")
        {
            showResume.gameObject.SetActive(true);
            Destroy(gameObject);            
            //playerScript.Heal(healAmount);             
        }
    }
}
