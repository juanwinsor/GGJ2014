﻿using UnityEngine;
using System.Collections;

public class GameSessionController : MonoBehaviour {
	
	Timer gameTimer = new Timer(90.0f);
	private bool rampageStarted = false;


	public int NumberOfPlayers = 0;
	public int NumberOfBeasts = 0;


	public NPCSpawner npcSpawner;
	public PlayerSpawner playerSpawner;

	public SpriteRenderer levelRenderer;
	public Sprite levelRampageSprite;

	public BeastAttackFlicker attackFlickerScript;
	
	public AudioController audioController;
	
	
	public GameObject[] bloodEffects;

	
	
	// Use this for initialization
	void Start () {
		
		GameSessionManager.Instance.npcSpawner = npcSpawner;
		GameSessionManager.Instance.playerSpawner = playerSpawner;
		
		GameSessionManager.Instance.gameSessionController = this.gameObject;
		GameSessionManager.Instance.audioController = audioController;

		GameSessionManager.Instance.attackFlickerScript = attackFlickerScript;

		GameSessionManager.Instance.GameStart();


		gameTimer.Start ();

	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.M))
		{
			GameSessionManager.Instance.BeastAttack();
		}
		
		if(Input.GetKeyDown(KeyCode.A))
		{
			
			GameSessionManager.Instance.HumanAttack();
		}


		//check if the game timer is done, if so we go into rampage mode
		if (gameTimer.Done && rampageStarted == false) 
		{
			//change map
			levelRenderer.sprite = levelRampageSprite;
			GameSessionManager.Instance.RampageModeStart();
			rampageStarted = true;
		}

		if (NumberOfPlayers == 0) 
		{
			//beast wins
			Debug.Log("BEAST WINS");

			StopControllerVibration();

			Application.LoadLevel("beastWin");



		}

		if (NumberOfBeasts == 0) 
		{
			//player wins
			Debug.Log("HUMANS WIN");

			StopControllerVibration();

			Application.LoadLevel("humanWin");
		}

	}

	public void StopControllerVibration()
	{
		for(int i = 0; i < 4; i++)
		{
			if(GamepadInput.Instance.state[i].IsConnected)
			{
				GamepadInput.Instance.setVibration(i, 0, 0);
			}
		}
	}

	public void SpawnBlood(Vector3 position)
	{
		int effectNumber = Random.Range (0, 5);		
		Instantiate(bloodEffects[effectNumber], position, Quaternion.identity);
	}
	
}
