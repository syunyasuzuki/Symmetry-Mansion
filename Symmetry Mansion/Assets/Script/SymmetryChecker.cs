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

    // Use this for initialization
    void Start () {

        //var strArray = new[] {GameObject.FindGameObjectsWithTag("Kagu")};
        //Array.Sort(strArray);
        Kagu = GameObject.FindGameObjectsWithTag("Kagu");//KaguのタグでKaguのオブジェクトを取得
        
        Symmetry = false;

    }

    // Update is called once per frame
    void Update()
    {

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
        for(int j = 0; j > Kagu.Length; j++)
        {
            if (j % 2 == 0)
            {
                x_total[j] = x_Multipel[j] + x_Multipel[j + 1];
            }
        }
        for(int k = 0; k < x_total.Length; k++)
        {
<<<<<<< HEAD
            if (-0.3f <= x_total[0] && x_total[0] <= 0.3)//-0.3または0.3の誤差内であればシンメトリーになる
=======
            if (-0.1f <= x_total[k] && x_total[k] <= 0.1)//-0.3または0.3の誤差内であればシンメトリーになる
>>>>>>> 9f5742a9432d9749e167f87fa328ebee6a381e00
            {
                Symmetry = true;
            }
            else
            {
                Symmetry = false;
            }
        }
    }
}
