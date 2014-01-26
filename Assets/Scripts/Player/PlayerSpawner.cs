using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject beastPrefab;
	//public GameObject humanPrefab;
	public SpriteRenderer levelSpriteRenderer;
	public GameObject[] humanList;
	public GameObject[] Spawners;

	public GameSessionController gameSession;


	int playercount = 0;

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

		SpawnPlayers ();

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void SpawnPlayers()
	{
		countPlayers();

		int beastNum = Random.Range(0, playercount);
		for (int i = 0; i < 4; i++) 
		{
			if(GamepadInput.Instance.state[i].IsConnected)
			{
				if(beastNum == i)
				{
					GameObject beast = Instantiate(beastPrefab) as GameObject;
					PlayerController playerControllerScript =  beast.GetComponent<PlayerController>();
					playerControllerScript.playerNumber = i;
					playerControllerScript.isBeastly = true;
					bool isInGoodSpot = false;
					//while(isInGoodSpot == false)
					{
					int theBoxNum = Random.Range(0,9);
						xRangeMin = Spawners[theBoxNum].gameObject.transform.position.x - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
						xRangeMax = Spawners[theBoxNum].gameObject.transform.position.x + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
						yRangeMin = Spawners[theBoxNum].gameObject.transform.position.y - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
						yRangeMax = Spawners[theBoxNum].gameObject.transform.position.y + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
						
						beast.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),beast.gameObject.transform.position.z);
					}
					GamepadInput.Instance.setVibration(i,0.3f,0.3f);

					//playerControllerScript.weapon.GetComponent<Weapon_Beast>().gameSession = gameSession;
					playerControllerScript.gameObject.GetComponent<Die>().gameSession = gameSession;

				}
				else
				{

					GameObject human = Instantiate(humanList[Random.Range(0,4)]) as GameObject;
					PlayerController playerControllerScript =  human.GetComponent<PlayerController>();
					playerControllerScript.playerNumber = i;
					
					int theBoxNum = Random.Range(0,9);
						xRangeMin = Spawners[theBoxNum].gameObject.transform.position.x - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
						xRangeMax = Spawners[theBoxNum].gameObject.transform.position.x + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.x / 2);
						yRangeMin = Spawners[theBoxNum].gameObject.transform.position.y - (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
						yRangeMax = Spawners[theBoxNum].gameObject.transform.position.y + (((BoxCollider2D)Spawners[theBoxNum].collider2D).size.y / 2);
						
					human.transform.position = new Vector3(Random.Range(xRangeMin, xRangeMax),Random.Range(yRangeMin, yRangeMax),human.gameObject.transform.position.z);

					//playerControllerScript.weapon.GetComponent<Weapon_Handgun>().gameSession = gameSession;
					playerControllerScript.gameObject.GetComponent<Die>().gameSession = gameSession;
				}
			}
		}
	}

	void countPlayers()
	{
		playercount = 0;
		for (int i = 0; i < 4; i++) 
		{
			if(GamepadInput.Instance.state[i].IsConnected)
			{
				playercount++;
			}
		}
	}
}
