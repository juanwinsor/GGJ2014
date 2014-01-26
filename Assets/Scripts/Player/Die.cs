using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public GameSessionController gameSession;

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
