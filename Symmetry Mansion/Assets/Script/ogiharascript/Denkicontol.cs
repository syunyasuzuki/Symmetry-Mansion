using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Denkicontol : MonoBehaviour
{
    public Image Dark;

    public static bool Dengen;
    public static bool DengenON;
    public static bool DengenOFF;

    public static float alpha;
    // Use this for initialization
    void Start()
    {
        alpha = 0.0f;
        Dengen = true;
        DengenON = true;
        DengenOFF = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dengen)
        {
            if (DengenON) DenkiON();
            if (DengenOFF) DenkiOFF();
        }
    }
    public void DenkiON()
    {
        alpha = 0.0f;
        Dark.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha <= 0.0f)
        {
            Dengen = false;
            DengenON = false;
        }
    }
    public void DenkiOFF()
    {
        alpha = 1.0f;
        Dark.color = new Color(1.0f, 1.0f, 1.0f, alpha);
        if (alpha >= 1.0f)
        {
            Dengen = false;
            DengenOFF = false;
        }
    }
}

