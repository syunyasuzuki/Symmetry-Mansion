using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanscript : MonoBehaviour {
    public Vector2 pos;
    bool set;
    private GameObject Player;
    // Use this for initialization
    void Start()
    {
        set = false;
        //GetComponent<kaidanscript>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)//プレイヤーが近くにいるとき
    {
        if (other.tag == "Player")
        {
            set = true;
            //GetComponent<kaidanscript>().enabled = true;
            //Debug.Log("チェック");
        }
    }
    void OnTriggerExsit2D(Collider2D other)//プレイヤーが離れた時
    {
        if (other.tag == "Player")
        {
            set = false;
            //GetComponent<kaidanscript>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        switch (set)
        {
            case true:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Player.transform.position = new Vector2(pos.x, pos.y);

                }
                break;
            case false:
                break;
        }



    }
}
