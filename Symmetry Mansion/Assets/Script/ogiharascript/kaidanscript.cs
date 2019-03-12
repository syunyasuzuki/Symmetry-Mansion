using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanscript : MonoBehaviour {
    public GameObject pos;
    bool set;
    private GameObject Player;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        set = false;
        //GetComponent<kaidanscript>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)//プレイヤーが近くにいるとき
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Player.transform.position = pos.transform.position;
            }
            //GetComponent<kaidanscript>().enabled = true;
            Debug.Log("チェック");
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
