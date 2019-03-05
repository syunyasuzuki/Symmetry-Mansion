using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karuikagu : MonoBehaviour {

    public GameObject Player;
    public GameObject kagu;
    public bool motu_set;
    public static bool parents_set;

    float Z;

    Collider2D kagu_ObjectCollider;

    // Use this for initialization
    void Start()
    {
        //持つsetはfalseでスタート
        motu_set = false;

        parents_set = false;

        //コライダーを取得
        kagu_ObjectCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //motu_setが起動かつZキーが押された時
        if (motu_set == true && Input.GetKeyDown(KeyCode.Z))
        {
            //コライダ　Trigger OFF 
            kagu_ObjectCollider.isTrigger = false;
        }

        //aがプレイヤと親子関係の時
        if (kagu.transform.parent == Player.transform)
        {
            //Zキーが押された時
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //親子関係解除
                kagu.transform.parent = null;

                /*position取得*/
                //Vector2 pos = Player.transform.position;
                //Player.transform.position = new Vector2(pos.x, pos.y);
                //X = pos.x;

                //家具の向き（ベクトル）を取得
                Vector3 pos = transform.position + transform.forward;

                //プレイヤの正面に置く
                kagu.transform.position = pos;

                //コライダ Trigger ON
                kagu_ObjectCollider.isTrigger = true;

                parents_set = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //プレイヤtagに触れているとき
        if (col.gameObject.tag == "Player")
        {
            //motu_set起動
            motu_set = true;

            Debug.Log("チェック");
        }
        else
        {
            //motu_set起動しない
            motu_set = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //motu_set起動しない
        motu_set = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //プレイヤtagに触れているとき
        if (col.gameObject.tag == "Player")
        {
            parents_set = true;

            //Vector2 pos = a.transform.position;
            //a.transform.position = new Vector2(pos.x, pos.y);

            //親子関係
            kagu.transform.parent = Player.transform;

            //a.transform.position = pos.y;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        //プレイヤtagに触れているとき
        if (col.gameObject.tag == "Player")
        {
            parents_set = true;

            //親子関係
            kagu.transform.parent = Player.transform;
        }
    }
}
