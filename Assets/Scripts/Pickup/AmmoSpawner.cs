using UnityEngine;
using System.Collections;

public class AmmoSpawner : MonoBehaviour {

	public GameObject ammoPrefab;
	public GameObject[] Spawners;

	public int ammoOnScreen = 0;

	float xRangeMin = 0;
	float xRangeMax = 0;
	float yRangeMin = 0;
	float yRangeMax = 0;

	Timer ammoTimer = new Timer(20);

	// Use this for initialization
	void Start () {
		ammoOnScreen = 0;
		ammoTimer.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ammoTimer.Done) 
		{
			if(ammoOnScreen < 3)
			{
				SpawnCrate();
				ammoTimer.Start ();
			}
			else
			{
				ammoTimer.Start ();
			}
		}
	}

	void SpawnCrate()
	{
		
		ammoOnScreen++;
		GameObject ammo = Instantiate(ammoPrefab) as GameObject;
		int theBoxNum = Random.Range(0,9);
		xRangeMin = Spawners[theBoxNum].gameObject.transform.position.x - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
		xRangeMax = Spawners[theBoxNum].gameObject.transform.position.x + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
		yRangeMin = Spawners[theBoxNum].gameObject.transform.position.y - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
		yRangeMax = Spawners[theBoxNum].gameObject.transform.position.y + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
		
		ammo.gameObject.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),ammo.gameObject.transform.position.z);
	}
}
