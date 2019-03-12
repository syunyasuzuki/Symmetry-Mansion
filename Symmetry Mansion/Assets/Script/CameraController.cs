using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        this.player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.player = GameObject.FindWithTag("Player");
        if (transform.position.x >= -1.31f && transform.position.x <= 1.32f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -1.31f)
        {
            transform.position = new Vector3(-1.31f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 1.33f)
        {
            transform.position = new Vector3(1.32f,transform.position.y, transform.position.z);
        }
        //Vector3 playerPos = this.player.transform.position;
        //transform.position = new Vector3(playerPos.x,
        //    -0.8f, transform.position.z);
    }
}
