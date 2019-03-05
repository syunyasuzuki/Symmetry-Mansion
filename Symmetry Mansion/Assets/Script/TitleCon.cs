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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeController.isFade1 = true;
            FadeController.isFadeOut1 = true;
            Invoke("Scene", 2.5f);
        }
	}
    void Scene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
