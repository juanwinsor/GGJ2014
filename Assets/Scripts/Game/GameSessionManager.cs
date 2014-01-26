using UnityEngine;
using System.Collections;

public class GameSessionManager : MonoBehaviour {

	public AudioController audioController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M))
		{
			
			GameStart();
		}

		if(Input.GetKeyDown(KeyCode.A))
		{

			GameStart();
		}

	}

	//when a game starts
	void GameStart()
	{
		//this.audio.volume = 0.8f;
		this.audio.loop = true;
		this.audio.clip = audioController.musicAmbient;
		this.audio.Play();
	}

	//when rampage mode starts
	void RampageModeStart()
	{
		this.audio.volume = 0.35f;
		this.audio.loop = true;
		this.audio.clip = audioController.musicRampage;
		this.audio.Play();
	}

	void BeastAttack()
	{
		this.audio.volume = 0.3f;
		this.audio.loop = true;
		this.audio.clip = audioController.musicTerror;
		this.audio.Play();
	}

	void HumanAttack()
	{


		this.audio.volume = 0.3f;
		this.audio.PlayOneShot(audioController.sfxGun);
	}

}
