using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour {

	public GameObject npcPrefab;
	public SpriteRenderer levelSpriteRenderer;
	public GameObject[] npcList;

	int numOfNPC = 100;
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
			npc.gameObject.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),npc.gameObject.transform.position.z);
		}
	}
}
