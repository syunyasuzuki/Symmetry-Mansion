using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_Player4 : MonoBehaviour {



    public static GameObject Player2;
    public GameObject Portal3;
    public GameObject Portal4;
    Animator animator;
    public static bool judg2;//入れ替わる際の判定用
    public static bool Ma;

    // Use this for initialization
    void Start()
    {
        Portal3 = GameObject.Find("Portal3");
        Portal4 = GameObject.Find("Portal4");
        Player2 = GameObject.Find("Player2");

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
        if (Reverse_Player3.Player.transform.position.x > 0.2f)
        {
            judg2 = true;
        }
        else if (Reverse_Player3.Player.transform.position.x > -0.2f)
        {
            judg2 = true;
        }

    }


    void OnCollisionStay2D(Collision2D other)//入れ替わり
    {
        if (Player2.transform.position.x < 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg2 == true)
            {
                FadeController.isFade3 = true;
                FadeController.isFadeOut3 = true;
                Invoke("judg_Portal", 0.75f);
            }
        }
        if (Player2.transform.position.x > 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && judg2 == true)
            {
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
        Player2.transform.position = Portal3.transform.position;
        Ma = true;
        judg2 = false;
        GetComponent<Reverse_Player4>().enabled = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player4>().enabled = true;
        Debug.Log("Reverse_Player4" + "T");
    }
    void judg_Portal2()
    {
        Player2.transform.position = Portal4.transform.position;
        Ma = false;
        judg2 = false;
        GetComponent<Reverse_Player4>().enabled = false;
        FadeController.isFade3 = true;
        FadeController.isFadeIn3 = true;
        GetComponent<Reverse_Player4>().enabled = true;
        Debug.Log("Reverse_Player4" + "F");
    }
}
