using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    public GameObject obj;
    public float x, y; 　　//objのx成分、y成分を格納する変数
   
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 pos = obj.transform.position;
        obj.transform.position = new Vector2(pos.x, pos.y);
        x = pos.x;
        y = pos.y;

        //Debug.Log(x);
        //Debug.Log(y);
    }
}
