using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 20.0f;
    float maxWalkSpeed = 1.5f;

    public GameObject[] kagu;
    public static bool parents_set;
    public static bool lag;
    public static bool muki_set;


    public AudioClip Walk_SE;  //歩くSEを入れる箱
    AudioSource Audio;         //SEを再生させるためのスイッチ
    int walk_count;            //walk_SEの再生頻度を調整するための変数

    public static GameObject _child;



    int z = 0;

    // Use this for initialization
    void Start()
    {
        kagu = GameObject.FindGameObjectsWithTag("Kagu");

        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        parents_set = false;
        muki_set = false;

        Audio = GetComponent<AudioSource>();
        Audio.clip = Walk_SE;

    }

    //アニメーションに合わせてSEを再生させるメソッド
    void walk_SE()
    {
        Audio.PlayOneShot(Walk_SE);
    }

    // Update is called once per frame
    void Update()
    {
        walk_count = 0;
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            walk_count++;
            key = 1;
            animator.SetTrigger("WalkTrigger");
            muki_set = true;

            //walk_countが10になったらwalk_SEメソッドを呼ぶ
            if (walk_count == 10)
            {
                walk_SE();
                walk_count = 0;   //walk_countリセット
            }

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            walk_count--;
            key = -1;
            animator.SetTrigger("WalkTrigger");
            muki_set = false;

            //walk_countが-10になったらwalk_SEメソッドを呼ぶ
            if (walk_count == -10)
            {
                walk_SE();
                walk_count = 0;   //walk_countリセット
            }
        }

        //親子関係を持っていないとき
        if (key == 0 && !parents_set)
        {
            animator.SetTrigger("Stand-byTrigger");
        }

        if (key == 0)
        {
            //滑らないように
            Stop();
        }

        //プレイヤの移動速度
        float speedx = Mathf.Abs(rigid2D.velocity.x);

        //速度制限
        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);
        }

        //反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //速度に応じてアニメーション速度を変える
        animator.speed = speedx / 2.0f;

        if (!parents_set)
        {
            if (Input.GetKeyDown(KeyCode.Z) && karuikagu.playertouch)
            {
                z++;

                if (z >= 1)
                {
                    //親子関係
                    GameObject.Find(karuikagu.kagu_name).transform.parent = transform;

                    ////向き（ベクトル）を取得
                    //Vector3 pos = transform.position + transform.forward;

                    //子オブジェクトを取得
                    _child = transform.Find(karuikagu.kagu_name).gameObject;

                    parents_set = true;

                    //karuikagu.kagu_name = null;

                    //子オブジェクトのレイヤーを上げる
                    _child.GetComponent<Renderer>().sortingOrder = 5;

                    if (muki_set)
                    {
                        Vector3 tmp = GameObject.Find("Player").transform.position;
                        Vector3 tmp2 = GameObject.Find(karuikagu.kagu_name).transform.position;
                        //GameObject.Find(karuikagu.kagu_name).transform.position
                        //    = new Vector3(tmp.x + 0.3f, tmp2.y, tmp2.z);
                        GameObject.Find(karuikagu.kagu_name).transform.position
                            = new Vector3(tmp.x, tmp2.y, tmp.z);
                        Debug.Log("右");
                    }
                    else
                    {
                        Vector3 tmp = GameObject.Find("Player").transform.position;
                        Vector3 tmp2 = GameObject.Find(karuikagu.kagu_name).transform.position;
                        //GameObject.Find(karuikagu.kagu_name).transform.position
                        //    = new Vector3(tmp.x - 0.3f, tmp2.y, tmp2.z);
                        GameObject.Find(karuikagu.kagu_name).transform.position
                            = new Vector3(tmp.x, tmp2.y, tmp.z);
                        Debug.Log("左");
                    }
                }

            }
        }
        else
        {

            if (!karuikagu.kagutouch)
            {
                //Zキーが押された時
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    z = 0;
                    if (z == 0)
                    {
                        for (int i = 0; i < kagu.Length; i++)
                        {
                            //親子関係解除
                            kagu[i].transform.parent = null;

                            parents_set = false;

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
