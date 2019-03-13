using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SymmetryChecker : MonoBehaviour {

    public float[] x_Multipel;//x座標を入れる箱
    public float[] x_total;   //計算したx座標を入れる箱
    public float[] y_Multipel;//y座標を入れる箱
    Vector2[] pos;            //座標を取得
    public GameObject[] Kagu;
    public static bool Symmetry;

    int check_count = 0;

    // Use this for initialization
    void Start () {

        //var strArray = new[] {GameObject.FindGameObjectsWithTag("Kagu")};
        //Array.Sort(strArray);
        //Kagu = GameObject.FindGameObjectsWithTag("Kagu");//KaguのタグでKaguのオブジェクトを取得
        
        Symmetry = false;
    }

    // Update is called once per frame
    void Update()
    {
        check_count = 0;

        pos = new Vector2[Kagu.Length];     //Kaguの座標を取得
        x_Multipel = new float[Kagu.Length];//Kaguのx座標を取得
        y_Multipel = new float[Kagu.Length];//Kaguのy座標を取得
        x_total = new float[Kagu.Length];   //Kaguのx座標の計算結果を表示

        //x座標とy座標の座標を毎回取得
        for (int i = 0; i < Kagu.Length; i++)
        {
            pos[i] = Kagu[i].transform.position;
            Kagu[i].transform.position = new Vector2(pos[i].x, pos[i].y);
            x_Multipel[i] = pos[i].x;
            y_Multipel[i] = pos[i].y;
        }

        for (int j = 0; j < Kagu.Length; j++)
        {
            if (j % 2 == 0)
            {
                x_total[j] = x_Multipel[j] + x_Multipel[j + 1];
            }
        }

        for (int k = 0; k < x_total.Length; k++)
        {
            if (-0.3f <= x_total[k] && x_total[k] <= 0.3)//-0.3または0.3の誤差内であればシンメトリーになる
            {
                check_count++;
                Debug.Log(check_count);
            }
        }

        if (check_count == x_total.Length)
        {
            Symmetry = true;
        }
    }
}
