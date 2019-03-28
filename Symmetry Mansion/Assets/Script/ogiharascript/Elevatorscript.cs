using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatorscript : MonoBehaviour {

    bool Elevator_set;//エレベータの電源を判定するやつ
    // Use this for initialization
    void Start () {
        Elevator_set = false;
        GetComponent<Elevatorscript>().enabled = false;        
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Elevator_set = true;
            GetComponent<Elevatorscript>().enabled = true;
        }
    }
	void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Elevator_set = false;
            GetComponent<Elevatorscript>().enabled = false;
        }
    }
	// Update is called once per frame
	void Update () {
        switch (DenkiContlloer.isDengen)
        {
            case true:
                switch (Elevator_set)
                {
                    case true:
                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            Elevator_set = false;
                        }
                        break;
                    case false:
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            Elevator_set = true;
                        }
                        break;
                }
                break;
            case false:                
                break;
        }
	}
}
