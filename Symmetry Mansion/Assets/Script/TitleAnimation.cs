using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    Animator animator;
    public static bool Fade_start;

    AudioSource audio;
    public AudioClip Game_start;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Fade_start = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            audio.PlayOneShot(Game_start);
            animator.SetTrigger("startTrigger");
            Invoke("FadeStart", 1.3f);
        }
	}
    void FadeStart()
    {
        Fade_start = true;
    }
}
