using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    Animator animator;
    float walkForce = 20.0f;
    float maxWalkSpeed = 1.5f;


    // Use this for initialization
    void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();     
	}
	
	// Update is called once per frame
	void Update ()
    {
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            key = 1;
            animator.SetTrigger("WalkTrigger");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            animator.SetTrigger("WalkTrigger");          
        }

        //待機
        if (key == 0&&karuikagu.parents_set == false)
        {
            //滑らないように
            rigid2D.velocity = new Vector2(0, -20);

            animator.SetTrigger("Stand-byTrigger");
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
    
}
