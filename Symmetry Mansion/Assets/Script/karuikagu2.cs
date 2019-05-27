using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class karuikagu2 : MonoBehaviour
{

    //public GameObject Player;
    //public GameObject kagu;
    //public static bool parents_set;

    public static bool playertouch2;
    public static string kagu_name2;
    public static bool kagutouch2;
    public GameObject carsor2;

    // Use this for initialization
    void Start()
    {
        carsor2 = GameObject.FindGameObjectWithTag("carsor2");

        //parents_set = false;   

        //playertouch = false;
        kagutouch2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        ////プレイヤと親子関係の時
        //if (kagu.transform.parent == Player.transform)
        //{
        //    //スタミナゲージを減らす
        //    GameObject director = GameObject.Find("GameDirector");
        //    director.GetComponent<GameDirector>().DecreasS();

        //    //Zキーが押されていない時
        //    if (Input.GetKeyDown(KeyCode.Z)&& parents_set)
        //    {
        //        Debug.Log("aaa");
        //        //親子関係解除
        //        kagu.transform.parent = null;
        //        parents_set = false;
        //    }

        //}
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    //プレイヤtagに触れているとき
    //    if (col.gameObject.tag == "Player" && parents_set == false)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Z))
    //        {
    //            Debug.Log("チェック");
    //            //親子関係
    //            kagu.transform.parent = Player.transform;

    //            //家具の向き（ベクトル）を取得
    //            Vector3 pos = transform.position + transform.forward;

    //            parents_set = true;
    //        }
    //    }
    //}

    void OnTriggerStay2D(Collider2D col)
    {
        //家具tagと触れたとき
        if (col.gameObject.tag == "Kagu2"&& col.gameObject.tag == "Kagu")
        {
            kagutouch2 = true;

            //PlayerController._child.GetComponent<Renderer>().sortingOrder = 5;
        }

        //プレイヤtagと触れたとき
        if (col.gameObject.tag == "Player2")
        {
            if (!PlayerController.parents_set)
            {
                //kagu_nameに格納する
                kagu_name2 = transform.name;

                Vector3 tmp2 = GameObject.Find(kagu_name2).transform.position;

                carsor2.transform.position
                         = new Vector3(tmp2.x, tmp2.y + 0.4f, tmp2.z);

                //子オブジェクトのレイヤーを上げる
                carsor2.GetComponent<Renderer>().sortingOrder = 5;

                if (Input.GetKey(KeyCode.Z))
                {
                    playertouch2 = true;
                }
                else
                {
                    playertouch2 = false;
                    kagu_name2 = null;
                }
            }

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        kagutouch2 = false;
        playertouch2 = false;

        //子オブジェクトのレイヤーを上げる
        carsor2.GetComponent<Renderer>().sortingOrder = -1;
    }
}
