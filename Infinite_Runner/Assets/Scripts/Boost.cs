using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public Player_2D Player;

    [SerializeField] float BoostSpeed=.1f;
    void Awake()
    {
        Player = FindObjectOfType<Player_2D>();
    }

    
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            Debug.Log("Boost");
            Player.speed = Player.speed + BoostSpeed;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        Player.speed = Player.speed - BoostSpeed;
	}
}
