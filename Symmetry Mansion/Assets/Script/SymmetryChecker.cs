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

        x_total[0] = x_Multipel[0] + x_Multipel[1];//x座標の計算
        if (-0.3f <= x_total[0] && x_total[0] <= 0.3)//-0.3または0.3の誤差内であればシンメトリーになる
        {
            Symmetry = true;
        }
        else
        {
            Symmetry = false;
        }

    }
}
