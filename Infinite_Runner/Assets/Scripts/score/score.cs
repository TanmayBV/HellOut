using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoretext;
    public float scorecount;
    public float pointpersecond;
    public bool scoreincreasing;
  
    void Start() 
    {
        
    }

    
    void Update()
    {
        scorecount += pointpersecond * Time.deltaTime;
        scoretext.text = "score: " + Mathf.Round(scorecount);
    }
}
