using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SymmetryChecker : MonoBehaviour {

    public float[] x_Multipel;//x座標を入れる箱
    public float[] x_total;   //計算したx座標を入れる箱
    public float[] y_Multipel;//y座標を入れる箱
    Vector2[] pos;            //X座標、Y座標を取得する変数
    public GameObject[] Kagu;
    public static bool Symmetry_check;
    int symmetry_count = 0;
    int check_count = 0;

    // Use this for initialization
    void Start()
    {

        //var strArray = new[] {GameObject.FindGameObjectsWithTag("Kagu")};
        //Array.Sort(strArray);
        //Kagu = GameObject.FindGameObjectsWithTag("Kagu");//KaguのタグがついているオブジェクトをKagu配列に入れる

        Symmetry_check = false;
    }

    // Update is called once per frame
    void Update()
    {
        check_count++;
        //check_countが30ごとにSymmetryメソッドを呼ぶ
        if (check_count == 30)
        {
            Symmetry();
            check_count = 0;
        }
    }
    void Symmetry()
    {
        symmetry_count = 0;
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
            if (-0.1f <= x_total[k] && x_total[k] <= 0.1)//-0.1または0.1の誤差内であればシンメトリーになる
            {
                symmetry_count++;
            }
        }
        if (symmetry_count == x_total.Length)
        {
            Symmetry_check = true;
            Debug.Log(Symmetry_check);
        }
    }
}
