using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeController.isFade = true;
            FadeController.isFadeOut = true;
            Invoke("Scene", 2.5f);

        }
    }
    void Scene()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
