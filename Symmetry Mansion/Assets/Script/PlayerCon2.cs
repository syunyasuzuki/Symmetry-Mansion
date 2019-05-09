using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon2 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 20.0f;
    float maxWalkSpeed = 1.5f;

    public AudioClip Walk_SE;  //歩くSEを入れる箱
    AudioSource Audio;         //SEを再生させるためのスイッチ
    int walk_count;            //walk_SEの再生頻度を調整するための変数
    private bool stop;

    // Use this for initialization
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Audio = GetComponent<AudioSource>();

    }

    //アニメーションに合わせてSEを再生させるメソッド
    void walk_SE()
    {
        Audio.PlayOneShot(Walk_SE);
    }

    // Update is called once per frame
    void Update()
    {
        stop = false;
        walk_count = 0;
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            walk_count++;
            key = 1;
            animator.SetTrigger("walkTrigger");
            stop = true;
            //walk_countが10になったらwalk_SEメソッドを呼ぶ
            if (walk_count == 10)
            {
                walk_SE();
                walk_count = 0;   //walk_countリセット
            }

        }

        if (Input.GetKey(KeyCode.RightArrow) && stop == false)
        {
            walk_count--;
            key = -1;
            animator.SetTrigger("walkTrigger");

            //walk_countが-10になったらwalk_SEメソッドを呼ぶ
            if (walk_count == -10)
            {
                walk_SE();
                walk_count = 0;   //walk_countリセット
            }
        }

        //親子関係を持っていないとき
        if (key == 0 && karuikagu2.parents_set2 == false)
        {
            animator.SetTrigger("stayTrigger");
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
    }

    //滑らないように
    void Stop()
    {
        rigid2D.velocity = Vector2.zero;
        //rigid2D.angularVelocity = Vector2.zero;
    }

}
