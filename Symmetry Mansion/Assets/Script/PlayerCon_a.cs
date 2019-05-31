using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon_a : MonoBehaviour {

    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 20.0f;
    float maxWalkSpeed = 1.5f;

    public GameObject[] kagu2;
    public static bool parents_set2;
    public static bool lag2;
    public static bool muki_set2;
    public static bool mp_set;

    public static GameObject _child;
    private bool stop;
    private GameObject Player2;


    int z = 0;

    // Use this for initialization
    void Start()
    {
        kagu2 = GameObject.FindGameObjectsWithTag("Kagu2");

        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        parents_set2 = false;
        muki_set2 = false;
        Player2 = GameObject.Find("Player2");
        GetComponent<PlayerCon_a>().enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Player2.transform.position.y < 0)
        {
            GetComponent<PlayerCon_a>().enabled = true;
        }
        else if (Player2.transform.position.y < 0)
        {
            GetComponent<PlayerCon_a>().enabled = false;
        }
        stop = false;
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = 1;
            if (Reverse_Player4.Ma)
            {
                animator.SetTrigger("walkTrigger");
            }
            else
            {
                animator.SetTrigger("Walk2Trigger");
            }

            muki_set2 = true;
            stop = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && stop == false)
        {

            key = -1;
            if (Reverse_Player4.Ma)
            {
                animator.SetTrigger("walkTrigger");
            }
            else
            {
                animator.SetTrigger("Walk2Trigger");
            }
            muki_set2 = false;

        }

        //親子関係を持っていないとき
        if (key == 0 /*&& !parents_set2*/)
        {
            if (Reverse_Player4.Ma)
            {
                animator.SetTrigger("stayTrigger");
            }
            else
            {
                animator.SetTrigger("stand-by2Trigger");
            }

        }

        if (key == 0)
        {
            //滑らないように
            Stop();
        }

        //プレイヤの移動速度
        //float speedx = Mathf.Abs(rigid2D.velocity.x);

        ////速度制限
        //if (speedx < maxWalkSpeed)
        //{
        //    rigid2D.AddForce(transform.right * key * walkForce);
        //}

        //反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        ////速度に応じてアニメーション速度を変える
        //animator.speed = speedx / 2.0f;

        if (!parents_set2)
        {
            if (Input.GetKeyDown(KeyCode.Z) && karuikagu2.playertouch2)
            {
                z++;

                if (z >= 1)
                {
                    //親子関係
                    GameObject.Find(karuikagu2.kagu_name2).transform.parent = transform;

                    ////向き（ベクトル）を取得
                    //Vector3 pos = transform.position + transform.forward;

                    //子オブジェクトを取得
                    _child = transform.Find(karuikagu2.kagu_name2).gameObject;

                    parents_set2 = true;

                    //karuikagu.kagu_name = null;

                    //子オブジェクトのレイヤーを上げる
                    _child.GetComponent<Renderer>().sortingOrder = 5;

                    if (muki_set2)
                    {
                        Vector3 tmp = GameObject.Find("Player2").transform.position;
                        Vector3 tmp2 = GameObject.Find(karuikagu2.kagu_name2).transform.position;
                        //GameObject.Find(karuikagu2.kagu_name2).transform.position
                        //    = new Vector3(tmp.x + 0.3f, tmp2.y, tmp2.z);
                        GameObject.Find(karuikagu2.kagu_name2).transform.position
                            = new Vector3(tmp.x, tmp2.y, tmp.z);
                        Debug.Log("右");
                    }
                    else
                    {
                        Vector3 tmp = GameObject.Find("Player2").transform.position;
                        Vector3 tmp2 = GameObject.Find(karuikagu2.kagu_name2).transform.position;
                        //GameObject.Find(karuikagu2.kagu_name2).transform.position
                        //    = new Vector3(tmp.x - 0.3f, tmp2.y, tmp2.z);
                        GameObject.Find(karuikagu2.kagu_name2).transform.position
                            = new Vector3(tmp.x, tmp2.y, tmp.z);
                        Debug.Log("左");
                    }
                }

            }
        }
        else
        {

            if (!karuikagu2.kagutouch2)
            {
                //Zキーが押された時
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    z = 0;
                    if (z == 0)
                    {
                        for (int i = 0; i < kagu2.Length; i++)
                        {
                            //親子関係解除
                            kagu2[i].transform.parent = null;

                            parents_set2 = false;

                            //子オブジェクトのレイヤーを下げる
                            _child.GetComponent<Renderer>().sortingOrder = 1;

                        }

                    }

                }
            }

        }
    }

    //滑らないように
    void Stop()
    {
        rigid2D.velocity = Vector2.zero;
        //rigid2D.angularVelocity = Vector2.zero;

    }


}
