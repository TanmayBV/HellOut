using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Player_2D Player;
    public CameraFollow Camera;
    [SerializeField] Text scoretext;
    [SerializeField] float scorecount;
    [SerializeField] float FastCounter=10f;
    [SerializeField] float pointpersecond;

    void Start() 
    {
        
    }

    
    void Update()
    {
        scorecount += pointpersecond * Time.deltaTime;
        scoretext.text = "Score: " + Mathf.Round(scorecount);

        if (scorecount>=FastCounter)
		{
            float Incremanter = 1;
            float PlayerSpeed = Player.speed;
            float CameraSpeed = Camera.Speed;

            Player.speed = Player.speed + Incremanter;
            Camera.Speed = Camera.Speed + Incremanter+.1f;
            FastCounter = scorecount + 20;
		}
    }
}
