﻿using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour {

	public GameSessionController gameSession;

	public GameObject npcPrefab;
	public SpriteRenderer levelSpriteRenderer;
	public GameObject[] npcList;
	public GameObject[] Spawners;

	int numOfNPC = 50;
	float xRangeMin = 0;
	float xRangeMax = 0;
	float yRangeMin = 0;
	float yRangeMax = 0;

	// Use this for initialization
	void Start () {
		xRangeMin = levelSpriteRenderer.bounds.center.x - levelSpriteRenderer.bounds.extents.x;
		xRangeMax = levelSpriteRenderer.bounds.center.x + levelSpriteRenderer.bounds.extents.x;
		yRangeMin = levelSpriteRenderer.bounds.center.y - levelSpriteRenderer.bounds.extents.y;
		yRangeMax = levelSpriteRenderer.bounds.center.y + levelSpriteRenderer.bounds.extents.y;

		spawnNPCs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnNPCs()
	{
		for(int i = 0; i < numOfNPC; i++)
		{
			GameObject npc = Instantiate(npcList[Random.Range(0,4)]) as GameObject;
			int theBoxNum = Random.Range(0,9);
			xRangeMin = Spawners[theBoxNum].gameObject.transform.position.x - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
			xRangeMax = Spawners[theBoxNum].gameObject.transform.position.x + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
			yRangeMin = Spawners[theBoxNum].gameObject.transform.position.y - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
			yRangeMax = Spawners[theBoxNum].gameObject.transform.position.y + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
			
			npc.gameObject.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),npc.gameObject.transform.position.z);

			npc.gameObject.GetComponent<Die>().gameSession = gameSession;
		}
	}
}
