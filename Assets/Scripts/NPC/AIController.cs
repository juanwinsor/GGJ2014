using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {

	int theDir = 0;
	float moveTimer = 0;
	float timeToNextMove = 0;

	public Movement movementScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		calcTime();
		
		if(timeToNextMove <= moveTimer)
		{
			timeToNextMove = Random.value * 3.0f;
			theDir = Random.Range(0,5);
			moveTimer = 0;

		}		

		movementScript.MoveDir (theDir);
	}

	void calcTime()
	{
		moveTimer += Time.deltaTime;
	}
}
