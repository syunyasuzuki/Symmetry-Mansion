using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCon : MonoBehaviour
{
    

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (TitleAnimation.Fade_start)
        {
            FadeController.isFade1 = true;
            FadeController.isFadeOut1 = true;
            Invoke("Scene", 1.0f);
        }
	}
    void Scene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
