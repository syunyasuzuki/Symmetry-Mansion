using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanscript : MonoBehaviour {
    public Vector2 pos;
    bool lever;
	// Use this for initialization
	void Start () {
        lever = false;
        GetComponent<denkiscript>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)//プレイヤーが近くにいるとき
    {
        if (other.tag == "Player")
        {
            lever = true;
            GetComponent<Denkicontol>().enabled = true;//スクリプトON
        }
    }
    void OnTriggerExit2D(Collider2D other)//プレイヤーが離れた時
    {
        if (other.tag == "Player")
        {
            lever = false;
            GetComponent<Denkicontol>().enabled = false;//スクリプトOFF        
        }
    }
    // Update is called once per frame
    void Update () {
        switch (lever) {
            case true:
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector2(pos.x, pos.y);
                    Denkicontol.Dengen = true;
                    Denkicontol .DengenOFF = true;
                    if (Denkicontol.alpha == 0)
                    {
                        Denkicontol.Dengen = true;
                        Denkicontol.DengenON = true;
                    }
                }
                break;
            case false:
                break;
        }
	}
    
}
