using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject beastPrefab;
	public GameObject humanPrefab;
	public SpriteRenderer levelSpriteRenderer;


	int playercount = 0;

	// Use this for initialization
	void Start () {
		SpawnPlayers ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnPlayers()
	{
		countPlayers();

		int beastNum = Random.Range(0, 3);
		for (int i = 0; i < 4; i++) 
		{
			if(GamepadInput.Instance.state[i].IsConnected)
			{
				if(beastNum == i)
				{
					GameObject beast = Instantiate(beastPrefab) as GameObject;
					PlayerController playerControllerScript =  beast.GetComponent<PlayerController>();
					playerControllerScript.playerNumber = i;
					bool isInGoodSpot = false;
					//while(isInGoodSpot == false)
					{
						beast.transform.position = new Vector3(2,2,beast.gameObject.transform.position.z);
					}
				}
				else
				{
					GameObject human = Instantiate(humanPrefab) as GameObject;
					PlayerController playerControllerScript =  human.GetComponent<PlayerController>();
					playerControllerScript.playerNumber = i;
					human.transform.position = new Vector3(2,2,human.gameObject.transform.position.z);
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
