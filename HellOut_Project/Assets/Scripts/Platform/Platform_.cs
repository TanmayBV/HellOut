using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_ : MonoBehaviour
{
	private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

	[SerializeField] private GameObject Container;
	[SerializeField] private Transform levelPart_Start;

	[SerializeField] private List<Transform> levelPartlist;
	[SerializeField] private List<Transform> Destoyer;

	[SerializeField] private Transform player;
	[SerializeField] private float DisBtnPaltform = 10f;
	[SerializeField] private float DestroyOffset = 2f, Distance = 22.89f, CurrentDistance;

	private int IndexDestroyer = 0;

	private Vector3 lastEndPosition;

	private void Awake()
	{
		CurrentDistance = Distance + DestroyOffset;
		CurrentDistance *= 2;
		Destoyer = new List<Transform>();
		lastEndPosition = levelPart_Start.Find("EndPosition").position;
		int startingSpawnLevelParts = 5;
		for (int i = 0; i < startingSpawnLevelParts; i++)
		{
			SpawnLevelPart();
		}
	}

	private void Update()
	{
		if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
		{
			SpawnLevelPart();
		}

		Abc();

	}

	private void SpawnLevelPart()
	{
		Transform choosenpart = levelPartlist[Random.Range(0, levelPartlist.Count)];
		Transform lastLevelPartTransform = SpawnLevelPart(choosenpart,lastEndPosition);
		lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
	}

	private Transform SpawnLevelPart(Transform levelPart,Vector3 spawnPosition)
	{
		Transform levelPartTransform = Instantiate(levelPart, new Vector3(spawnPosition.x + DisBtnPaltform,0,0), Quaternion.identity);
		levelPartTransform.parent = Container.transform;
		Destoyer.Add(levelPartTransform);
		return levelPartTransform;
	}

	private void Abc()
	{
		if (player.position.x > CurrentDistance)
		{
			Destroy(Destoyer[IndexDestroyer].gameObject);
			IndexDestroyer++;
			CurrentDistance += DestroyOffset + Distance;
		}
	
	}

}
