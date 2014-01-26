using UnityEngine;
using System.Collections;

public class GameSessionController : MonoBehaviour {
	
	
	public NPCSpawner npcSpawner;
	public PlayerSpawner playerSpawner;
	
	public AudioController audioController;
	
	
	public GameObject[] bloodEffects;
	
	
	
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
	
	public void SpawnBlood(Vector3 position)
	{
		int effectNumber = Random.Range (0, 5);		
		Instantiate(bloodEffects[effectNumber], position, Quaternion.identity);
	}
	
}
