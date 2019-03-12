using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanCon : MonoBehaviour
{
    private GameObject Player;
    public GameObject kaidan;

    
    //public float pos_x, pos_y;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {               
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("KaidanMove", 2);
            }
        }
    }   
    void KaidanMove()
    {
        Player.transform.position = kaidan.transform.position;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
    }
}
