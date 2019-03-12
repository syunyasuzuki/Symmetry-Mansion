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

        //ｘ座標指定
        if (transform.position.x >= -1.37f && transform.position.x <= 1.36f &&
           transform.position.y >= -0.77f && transform.position.y <= 0.79f)
        {
            transform.position = new Vector3(player.transform.position.x,   player.transform.position.y + 0.77f, transform.position.z);
        }
        if (transform.position.x < -1.37f)
        {
            transform.position = new Vector3(-1.36f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 1.36f)
        {
            transform.position = new Vector3(1.35f,transform.position.y, transform.position.z);
        }

        //ｙ座標指定
        if (transform.position.y > 0.79f)
        {
            transform.position = new Vector3(player.transform.position.x, 0.79f, transform.position.z);
            if (transform.position.x < -1.37f)
            {
                transform.position = new Vector3(-1.36f, 0.79f, transform.position.z);
            }
            if (transform.position.x > 1.37f)
            {
                transform.position = new Vector3(1.36f, 0.79f, transform.position.z);
            }
        }

        if (transform.position.y < -0.77f)
        {
            transform.position = new Vector3(player.transform.position.x, -0.77f, transform.position.z);
            if (transform.position.x < -1.37f)
            {
                transform.position = new Vector3(-1.36f, -0.77f, transform.position.z);
            }
            if (transform.position.x > 1.37f)
            {
                transform.position = new Vector3(1.36f, -0.77f, transform.position.z);
            }
        }

        //Vector3 playerPos = this.player.transform.position;
        //transform.position = new Vector3(playerPos.x,
        //    -0.8f, transform.position.z);
    }
}
