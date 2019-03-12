using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karuikagu : MonoBehaviour
{

    public GameObject Player;
    public GameObject kagu;
    public bool motu_set;
    public static bool parents_set;

    float Z;

    // Use this for initialization
    void Start()
    {
        //持つsetはfalseでスタート
        motu_set = false;

        parents_set = false;

      

    }

    // Update is called once per frame
    void Update()
    {
        //Zキーが押された時
        if (Input.GetKey(KeyCode.Z))
        {
            
                //motu_set起動
                motu_set = true;
            
          
        }

        //aがプレイヤと親子関係の時
        if (kagu.transform.parent == Player.transform)
        {
            //スタミナゲージを減らす
            //GameObject director = GameObject.Find("GameDirector");
            //director.GetComponent<GameDirector>().DecreasS();

            //Zキーが押された時
            if (Input.GetKeyUp(KeyCode.Z))
            {
                //motu_set起動しない
                motu_set = false;

                //GameObject director = GameObject.Find("GameDirector");
                //director.GetComponent<GameDirector>().DecreasS();

                if (motu_set == false)
                {
                    //親子関係解除
                    kagu.transform.parent = null;

                    parents_set = false;
                }

            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
       
        //プレイヤtagに触れているとき
        if (motu_set == true && col.gameObject.tag == "Player")
        {
            //家具の向き（ベクトル）を取得
            Vector3 pos = transform.position + transform.forward;

            //親子関係
            kagu.transform.parent = Player.transform;

            parents_set = true;

            //プレイヤの正面に置く
            kagu.transform.position = pos;


        }
    }
}
