using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanCon : MonoBehaviour
{
    private GameObject Player;
    public static bool kaidan_check;
    public float pos_x, pos_y;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Character");
        kaidan_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (kaidan_check == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Player.transform.position = new Vector2(pos_x, pos_y);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            kaidan_check = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        kaidan_check = false;
    }
}
