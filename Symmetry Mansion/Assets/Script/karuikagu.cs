using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class karuikagu : MonoBehaviour
{

    //public GameObject Player;
    //public GameObject kagu;
    //public static bool parents_set;

    public static bool playertouch;
    public static string kagu_name;
    public static bool kagutouch;

    // Use this for initialization
    void Start()
    {
        //parents_set = false;   

        //playertouch = false;
        kagutouch = false;
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
        if (col.gameObject.tag == "Kagu")
        {
            kagutouch = true;

            //PlayerController._child.GetComponent<Renderer>().sortingOrder = 5;
        }

        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Z) && !PlayerController.parents_set)
            {
                kagu_name = transform.name;

                playertouch = true;
            }
            else
            {
                playertouch = false;
                kagu_name = null;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        kagutouch = false;
        playertouch = false;
    }
}
