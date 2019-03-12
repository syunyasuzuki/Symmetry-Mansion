using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    Animator animator;
    bool open_set;
    //private AudioSource Get;

	// Use this for initialization
	void Start ()
    {
        open_set = false;
        animator = GetComponent<Animator>();
        //Get = GetComponent<AudioSource>();
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"&&SymmetryChecker.Symmetry == true)
        {
            open_set = true;
            Debug.Log("チェック");
        }
        else
        {
            open_set = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        open_set = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (open_set == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Open");
            //Get.Play();
            Invoke("Next", 1.0f);
        }
	}

    private void Next()
    {
        FadeController.isFade2 = true;
        FadeController.isFadeOut2 = true;

        SceneManager.LoadScene("ClearScene");
    }
}
