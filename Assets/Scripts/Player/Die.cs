using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public GameSessionController gameSession;
	public GameObject smilePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void kill()
	{
		if (gameSession != null) 
		{
			gameSession.SpawnBlood (this.transform.position);
			if(this.tag == "Human")
			{
				GameObject smile = Instantiate(smilePrefab) as GameObject;
				smile.gameObject.transform.position = this.gameObject.transform.position;
				gameSession.NumberOfPlayers--;
			}
			if(this.tag == "Beast")
			{
				gameSession.NumberOfBeasts--;
			}
			Destroy (this.gameObject);
		}
	}
}
