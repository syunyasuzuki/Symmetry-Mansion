using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_Player2 : MonoBehaviour {


    public static GameObject Player2;
    public GameObject Portal;
    public GameObject Portal2;
    public static bool judg2;//入れ替わる際の判定用
    Animator animator;
    public static bool MA;

    // Use this for initialization
    void Start()
    {
        Portal = GameObject.Find("Portal");
        Portal2 = GameObject.Find("Portal2");
        Player2 = GameObject.Find("Player2");
        MA = true;
    }

    // Update is called once per frame
    void Update()
    {
        judg2 = false;
        //Debug.Log(Player.transform.position);
        //Debug.Log(Player2.transform.position);        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player2 " + judg2);
        }
        if (Reverse_Player.Player.transform.position.x > 0.2f)
        {
            judg2 = true;
        }
        else if (Reverse_Player.Player.transform.position.x > -0.2f)
        {
            judg2 = true;
        }

    }
    void OnCollisionStay2D(Collision2D other)//入れ替わり
    {
        if (Player2.transform.position.x <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg2 == true)
            {
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("judg_Portal", 0.75f);
            }
        }
        if (Player2.transform.position.x >= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg2 == true)
            {
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("judg_Portal2", 0.75f);
            }
        }
    }
    void judg_Portal()
    {
        Player2.transform.position = Portal.transform.position;
        MA = true;
        judg2 = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player2>().enabled = false;
        GetComponent<Reverse_Player2>().enabled = true;
        Debug.Log("Reverse_Player2" + "T");
     
    }
    void judg_Portal2()
    {
        Player2.transform.position = Portal2.transform.position;
        MA = false;
        judg2 = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player2>().enabled = false;
        GetComponent<Reverse_Player2>().enabled = true;
        Debug.Log("Reverse_Player2"+"F");
    }
}