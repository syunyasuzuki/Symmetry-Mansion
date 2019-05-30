using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    Animator animator;
    public static bool Fade_start;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        Fade_start = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("startTrigger");
            Invoke("start", 1.5f);
        }
	}
    void start()
    {
        Fade_start = true;
    }
}
