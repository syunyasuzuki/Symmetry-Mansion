using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_Player : MonoBehaviour {

    public static GameObject Player;
    public GameObject Portal;
    public GameObject Portal2;
    public static bool judg;//入れ替わる際の判定用


    // Use this for initialization
    void Start()
    {
        Portal = GameObject.Find("Portal");
        Portal2 = GameObject.Find("Portal2");
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
        if (Reverse_Player2.Player2.transform.position.x < 0.20f)
        {
            judg = true;
        }
        else if (Reverse_Player2.Player2.transform.position.x < -0.20f)
        {
            judg = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)//入れ替わり
    {
        if (Player.transform.position.x >= 0)
        {
            if (Input.GetKeyDown(KeyCode.X)&& judg == true)
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
        Player.transform.position = Portal2.transform.position;
        judg = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player>().enabled = false;
        GetComponent<Reverse_Player>().enabled = true;

    }

    void judg_Portal2()
    {
        Player.transform.position = Portal.transform.position;
        judg = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player>().enabled = false;
        GetComponent<Reverse_Player>().enabled = true;
    }
}
