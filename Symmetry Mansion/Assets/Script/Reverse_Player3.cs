using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_Player3 : MonoBehaviour {
    public static GameObject Player;
    public GameObject Portal3;
    public GameObject Portal4;
    public static bool judg;//入れ替わる際の判定用


    // Use this for initialization
    void Start()
    {
        Portal3 = GameObject.Find("Portal3");
        Portal4 = GameObject.Find("Portal4");
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        judg = false;

        //Debug.Log(Player.transform.position);
        //Debug.Log(Player2.transform.position);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player " + judg);
        }
        if (Reverse_Player4.Player2.transform.position.x < 0.2f)
        {
            judg = true;
        }
        if (Reverse_Player4.Player2.transform.position.x < -0.2f)
        {
            judg = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)//入れ替わり
    {
        if (Player.transform.position.x >= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg == true)
            {
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("judg_Portal", 0.75f);
            }
        }
        if (Player.transform.position.x <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg == true)
            {
                //GetComponent<PlayerCon2>().enabled = false;
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("judg_Portal2", 0.75f);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
    void judg_Portal()
    {
        Player.transform.position = Portal4.transform.position;
        judg = false;
        GetComponent<Reverse_Player3>().enabled = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player3>().enabled = true;

    }

    void judg_Portal2()
    {
        Player.transform.position = Portal3.transform.position;
        judg = false;
        GetComponent<Reverse_Player3>().enabled = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player3>().enabled = true;
    }
}
