using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_ : MonoBehaviour
{
	private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

	[SerializeField] private Transform levelPart_Start;
	[SerializeField] private List<Transform> levelPartlist;
	[SerializeField] private Transform player;
	[SerializeField] private float Offset = 10f;

	private Vector3 lastEndPosition;

	private void Awake()
	{
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
	}

	private void SpawnLevelPart()
	{
		Transform choosenpart = levelPartlist[Random.Range(0, levelPartlist.Count)];
		Transform lastLevelPartTransform = SpawnLevelPart(choosenpart,lastEndPosition);
		lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
	}

	private Transform SpawnLevelPart(Transform levelPart,Vector3 spawnPosition)
	{
		Transform levelPartTransform = Instantiate(levelPart, new Vector3(spawnPosition.x + Offset,0,0), Quaternion.identity);
		return levelPartTransform;
	}
}
