using UnityEngine;
using System.Collections;

public class GameSessionManager {

	public GameObject gameSessionController;
	public AudioController audioController;



	private static GameSessionManager m_Instance = null;
	
	public static GameSessionManager Instance
	{
		get
		{
			if(m_Instance == null)
			{
				m_Instance = new GameSessionManager();
			}
			
			return m_Instance;
		}
	}




	//when a game starts
	public void GameStart()
	{
		//this.audio.volume = 0.8f;
		gameSessionController.audio.loop = true;
		gameSessionController.audio.clip = audioController.musicAmbient;
		gameSessionController.audio.Play();
	}

	//when rampage mode starts
	public void RampageModeStart()
	{
		gameSessionController.audio.volume = 0.35f;
		gameSessionController.audio.loop = true;
		gameSessionController.audio.clip = audioController.musicRampage;
		gameSessionController.audio.Play();
	}

	public void BeastAttack()
	{
		gameSessionController.audio.PlayOneShot(audioController.sfxScratch);
	}

	public void BeastAttackMode()
	{
		gameSessionController.audio.volume = 0.3f;
		gameSessionController.audio.loop = true;
		gameSessionController.audio.clip = audioController.musicTerror;
		gameSessionController.audio.Play();
	}

	public void BeastAttackModeEnd()
	{

	}

	public void HumanAttack()
	{
		gameSessionController.audio.volume = 0.3f;
		gameSessionController.audio.PlayOneShot(audioController.sfxGun);
	}

	public void BeastWins()
	{

	}

	public void HumansWin()
	{

	}

}
