using UnityEngine;
using System.Collections;

public class GameSessionManager : MonoBehaviour {

	public AudioController audioController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A))
		{
			//this.audio.clip = audioController.musicAmbient;
			//this.audio.loop = true;
			//this.audio.Play();
		}
	}

	//when a game starts
	void GameStart()
	{

	}

	//when rampage mode starts
	void RampageModeStart()
	{

	}

	void BeastAttack()
	{

	}

	void HumanAttack()
	{

	}

}
