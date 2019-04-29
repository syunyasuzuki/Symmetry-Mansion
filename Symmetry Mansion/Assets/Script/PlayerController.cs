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


    public AudioClip Walk_SE;  //歩くSEを入れる箱
    AudioSource Audio;         //SEを再生させるためのスイッチ
    int walk_count;            //walk_SEの再生頻度を調整するための変数

    public static GameObject _child;

    // Use this for initialization
    void Start()
    {
        kagu = GameObject.FindGameObjectsWithTag("Kagu");

        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        parents_set = false;

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
            if (Input.GetKey(KeyCode.Z) && karuikagu.playertouch)
            {
                //親子関係
                GameObject.Find(karuikagu.kagu_name).transform.parent = transform;

                //家具の向き（ベクトル）を取得
                Vector3 pos = transform.position + transform.forward;

                _child = transform.Find(karuikagu.kagu_name).gameObject;

                parents_set = true;

                Debug.Log("持つ");

                karuikagu.kagu_name = null;

                _child.GetComponent<Renderer>().sortingOrder = 5;

            }
        }
        else
        {
            //スタミナゲージを減らす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreasS();

            if (!karuikagu.kagutouch)
            {
                //Zキーが押された時
                if (Input.GetKeyDown(KeyCode.X))
                {
                    for (int i = 0; i < kagu.Length; i++)
                    {
                        Debug.Log("降ろす");
                        //親子関係解除
                        kagu[i].transform.parent = null;

                        parents_set = false;

                        _child.GetComponent<Renderer>().sortingOrder = 1;
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
