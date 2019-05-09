using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karuikagu2 : MonoBehaviour
{
    public GameObject Player2;
    public GameObject kagu2;
    public static bool parents_set2;

    // Use this for initialization
    void Start()
    {
        parents_set2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤと親子関係の時
        if (kagu2.transform.parent == Player2.transform)
        {
            //スタミナゲージを減らす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreasS();

            //Xキーが押されていない時
            if (Input.GetKeyUp(KeyCode.Z))
            {
                //親子関係解除
                kagu2.transform.parent = null;

                parents_set2 = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //プレイヤtagに触れているとき       
        if (col.gameObject.tag == "Player2" && parents_set2 == false)
        {
            Debug.Log("判定");
            if (Input.GetKey(KeyCode.Z))
            {
                //親子関係
                kagu2.transform.parent = Player2.transform;

                //家具の向き（ベクトル）を取得
                Vector3 pos = transform.position + transform.forward;

                parents_set2 = true;
            }
        }
    }
}
