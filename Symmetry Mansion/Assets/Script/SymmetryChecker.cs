using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetryChecker : MonoBehaviour {

    public float[] x_Multipel;//x座標を入れる箱
    public float[] x_total;   //計算したx座標を入れる箱
    public float[] y_Multipel;//y座標を入れる箱
    Vector2[] pos;            //座標を取得
    public GameObject[] Kagu;
    public static bool Symmetry;


    // Use this for initialization
    void Start () {

        Kagu = GameObject.FindGameObjectsWithTag("Kagu");//KaguのタグでKaguのオブジェクトを取得
        Symmetry = false;

    }

    // Update is called once per frame
    void Update()
    {

        pos = new Vector2[Kagu.Length];
        x_Multipel = new float[Kagu.Length];
        y_Multipel = new float[Kagu.Length];
        x_total = new float[Kagu.Length];

        for (int i = 0; i < Kagu.Length; i++)
        {
            pos[i] = Kagu[i].transform.position;//posで
            Kagu[i].transform.position = new Vector2(pos[i].x, pos[i].y);//
            x_Multipel[i] = pos[i].x;
            y_Multipel[i] = pos[i].y;

        }

        x_total[0] = x_Multipel[0] + x_Multipel[1];//x座標の計算
        if (-0.3f <= x_total[0] && x_total[0] <= 0.3)
        {
            Symmetry = true;
        }
        else
        {
            Symmetry = false;
        }

    }
}
