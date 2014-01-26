using UnityEngine;
using System.Collections;

public class Weapon_Handgun : MonoBehaviour {

	public GameSessionController gameSession;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject != null) 
		{
			if(other != null)
			{
				Die dieScript = other.gameObject.GetComponent<Die>();

				if(dieScript != null)
				{
					dieScript.kill();
				}

			}
		}
	}
}
