using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour {

	public GameObject npcPrefab;

	int numOfNPC = 50;
	float xRangeMin = 2;
	float xRangeMax = 15.0f;
	float yRangeMin = 2;
	float yRangeMax = 8.0f;

	// Use this for initialization
	void Start () {
		spawnNPCs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnNPCs()
	{
		for(int i = 0; i < numOfNPC; i++)
		{
			GameObject npc = Instantiate(npcPrefab) as GameObject;
			npc.gameObject.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),npc.gameObject.transform.position.z);
		}
	}
}
