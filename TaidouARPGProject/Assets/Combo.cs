﻿using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {
    
    public static Combo _instance;
    public float comboTime = 2;//连击时间
    private int comboCount = 0;//连击数
    private float timer = 0;
    private UILabel numberLabel;

    void Awake() {
        _instance = this;
        numberLabel = transform.Find("NumberLabel").GetComponent<UILabel>();
        this.gameObject.SetActive(false);
    }
    void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            this.gameObject.SetActive(false);
            comboCount = 0;
        }
    }


    public void ComboPlus() {//增加连击
        this.gameObject.SetActive(true);
        timer = comboTime;
        comboCount++;
        numberLabel.text = comboCount.ToString();
        transform.localScale = Vector3.one;
        iTween.ScaleTo(this.gameObject,new Vector3(1.5f,1.5f,1.5f),0.1f);
        iTween.ShakePosition(this.gameObject, new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
    }

}
