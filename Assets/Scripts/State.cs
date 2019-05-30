using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{

    public int difficulty =1;
    public int score =0 ;

    public int current_biome =0 ;
    
    //BUFF ARRay

    public bool isDead = false;


    public float transition = 0;
    public float animDur = 2.0f;


    public Text scoreText;

    public float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animDur)
            transition+= Time.deltaTime / animDur;
        else
            transition = 1.0f;
        
        scoreText.text =score.ToString();
        if (score > 100)
        {
            difficulty = Math.Min(score/100,3);//todo better - this WILL crash
            
        }
    }
}
