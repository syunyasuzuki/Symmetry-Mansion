using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karuikagu : MonoBehaviour
{

    public GameObject Player;
    public GameObject kagu;
    public static bool parents_set;

    // Use this for initialization
    void Start()
    {     
        parents_set = false;           
    }

    // Update is called once per frame
    void Update()
    {


        //プレイヤと親子関係の時
        if (kagu.transform.parent == Player.transform)
        {
            //スタミナゲージを減らす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreasS();

            //Zキーが押されていない時
            if (Input.GetKeyUp(KeyCode.Z))
            {           
                //親子関係解除
                kagu.transform.parent = null;

                parents_set = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //プレイヤtagに触れているとき
        if (col.gameObject.tag == "Player" && parents_set == false)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                //親子関係
                kagu.transform.parent = Player.transform;

                //家具の向き（ベクトル）を取得
                Vector3 pos = transform.position + transform.forward;

                parents_set = true;
            }
        }
    }
}
