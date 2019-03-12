using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    GameObject SGauge;

    // Use this for initialization
    void Start()
    {
        SGauge = GameObject.Find("SGauge");
    }

    // Update is called once per frame
    void Update()
    {
        if (SGauge.GetComponent<Image>().fillAmount ==0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void DecreasS()
    {
        SGauge.GetComponent<Image>().fillAmount -= 0.00010f;      
    }
}
