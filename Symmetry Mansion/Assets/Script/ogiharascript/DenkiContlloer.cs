using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DenkiContlloer : MonoBehaviour {

    public Image DarkImage;

    public static bool isDengen;
    public static bool isDengenON;
    public static bool isDengenOFF;

    float alpha;

    // Use this for initialization
    void Start()
    {
        alpha = 0.0f;
        isDengen = true;
        isDengenON = true;
        isDengenOFF = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDengen)
        {
            if (isDengenON) DengenON();
            if (isDengenOFF) DengenOFF();
        }
    }
    public void DengenON()
    {
        alpha = 0.0f;
        DarkImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            isDengen = false;
            isDengenON = false;
        }
    }
    public void DengenOFF()
    {
        alpha = 1.0f;
        DarkImage.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha >= 1.0f)
        {
            isDengen = false;
            isDengenOFF = false;
        }
    }
}

