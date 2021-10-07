using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon_SlowMotion : MonoBehaviour
{
    public Player_2D Player;
    public CameraFollow cam;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider != null)
		{
			Player.speed = Player.speed * 0.7f;
			cam.Speed = cam.Speed * 0.7f;
			Destroy(gameObject);
		}
	}

}
