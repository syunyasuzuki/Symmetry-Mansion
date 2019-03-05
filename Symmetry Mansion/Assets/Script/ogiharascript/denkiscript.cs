using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class denkiscript : MonoBehaviour {
       
    public static bool lever_set; //レバー    
    void Start()
    {
        lever_set = false;       
        GetComponent<denkiscript>().enabled = false;//スクリプトOFF        
    }
    void OnTriggerStay2D(Collider2D other)//プレイヤーが近くにいるとき
    {
        if (other.tag == "Player")
        {
            lever_set = true;            
            GetComponent<denkiscript>().enabled = true;//スクリプトON
        }
    }
    void OnTriggerExit2D(Collider2D other)//プレイヤーが離れた時
    {
        if (other.tag == "Player")
        {
            lever_set = false;                      
            GetComponent<denkiscript>().enabled = false;//スクリプトOFF        
        }
    }
    void Update()
    {
        switch (lever_set)
        {
            case true:
                if (Input.GetKeyDown(KeyCode.Z))
                {                    
                    lever_set = false;
                    DenkiContlloer.isDengen = true;
                    DenkiContlloer.isDengenOFF = true;
                }
                    break;
            case false:
                if (Input.GetKeyDown(KeyCode.Z))
                {                   
                    lever_set = true;
                    DenkiContlloer.isDengen = true;
                    DenkiContlloer.isDengenON = true;
                }
                break;
        }
    }   
}
