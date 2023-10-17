using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    [SerializeField] private Player_2D Player;
    [SerializeField] private CameraFollow Camera;
    [SerializeField] private Text scoretext;
    [SerializeField] private Text highScore;
    [SerializeField] private Text currentScore;

    [SerializeField] private float Incremanter = 0.2f;
    [SerializeField] float FastCounter = 10f;
    [SerializeField] float pointpersecond=2f;
     private float Score;
     private float scorecount;
    

    private void Update()
    {
        scorecount += pointpersecond * Time.deltaTime;
        Score = Mathf.Round(scorecount);
        scoretext.text = "Score : " + Score;
        
        currentScore.text = "Score : " + Score;
        highScore.text = "HighScore : " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
        
        if (Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            currentScore.enabled = false;
            PlayerPrefs.SetFloat("HighScore",Score);
            highScore.text = "HighScore : "+ Score;
        }
       
        if (Score >= FastCounter)
        {
            SpeedIncreament();
        }
    }
    private void SpeedIncreament()
    {
        Player.speed = Player.speed + Incremanter;
        Camera.Speed = Camera.Speed + Incremanter;
        FastCounter = scorecount + 10;
    }

}
