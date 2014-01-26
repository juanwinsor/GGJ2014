using UnityEngine;
using System.Collections;

public class GameSessionController : MonoBehaviour {


	public NPCSpawner npcSpawner;
	public PlayerSpawner playerSpawner;

	public AudioController audioController;

	// Use this for initialization
	void Start () {

		GameSessionManager.Instance.npcSpawner = npcSpawner;
		GameSessionManager.Instance.playerSpawner = playerSpawner;

		GameSessionManager.Instance.gameSessionController = this.gameObject;
		GameSessionManager.Instance.audioController = audioController;

		GameSessionManager.Instance.GameStart();

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

	}

}
