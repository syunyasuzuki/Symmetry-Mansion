using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    public Image FadeImage;
    public static bool isFade;
    public static bool isFadeOut;
    public static bool isFadeIn;
    float alpha;
	// Use this for initialization
	void Start () {
        alpha = 1.0f;
        isFade = true;
        isFadeIn = true;
        isFadeOut = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (isFade)
        {
            if (isFadeIn)
            {
                FadeIn();
            }
            else if(isFadeOut)
            {
                FadeOut();
            }

        }
	}

    public void FadeIn()
    {
        alpha -= 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            isFadeIn = false;
            isFade = false;
        }
    }

    public void FadeOut()
    {
        alpha += 0.05f;
        FadeImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            isFadeOut = false;
            isFade = false;
        }
    }

}
