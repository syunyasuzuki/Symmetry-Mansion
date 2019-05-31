using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    Animator animator;
    bool open_set1;
    bool open_set2;
    
    //private AudioSource Get;

	// Use this for initialization
	void Start ()
    {
        open_set1 = false;
        open_set2 = false;
        animator = GetComponent<Animator>();
        //Get = GetComponent<AudioSource>();
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            open_set1 = true;
            //Debug.Log("チェック");
        }
        else
        {
            open_set1 = false;
        }
        if (col.gameObject.tag == "Player2")
        {
            open_set2 = true;
            //Debug.Log("チェック");
        }
        else
        {
            open_set2 = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        open_set1 = false;
        open_set2 = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (open_set1 && open_set2 && SymmetryChecker.Symmetry_check == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetTrigger("Open");
                FadeController.isFade2 = true;
                FadeController.isFadeOut2 = true;
                //Get.Play();
            }
        }
	}
}
