using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanCon2 : MonoBehaviour
{

    private GameObject Player2;
    public GameObject kaidan2;


    //public float pos_x, pos_y;

    // Use this for initialization
    void Start()
    {
        Player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player2")
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
        Player2.transform.position = kaidan2.transform.position;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
    }
}