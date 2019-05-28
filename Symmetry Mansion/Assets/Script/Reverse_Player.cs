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
        if (Reverse_Player2.Player2.transform.position.x < 0.2f)
        {
            judg = true;
        }
        else if (Reverse_Player2.Player2.transform.position.x < -0.2f)
        {
            judg = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)//入れ替わり
    {
        judg = true;
        if (Player.transform.position.x >= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg == true)
            {
                Invoke("judg_Portal", 0.75f);
            }
        }
        else if (Player.transform.position.x <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg == true)
            {
                Invoke("judg_Portal2", 0.75f);
            }
        }
    }
    void judg_Portal()
    {
        Player.transform.position = Portal2.transform.position;
    }

    void judg_Portal2()
    {
        Player.transform.position = Portal.transform.position;
    }
}
