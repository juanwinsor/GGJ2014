using UnityEngine;
using System.Collections;

public class AttackEvents : MonoBehaviour {

	public GameObject damageDealer;
	public float activationTime = 0.1f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void startAttack()
	{
		Debug.Log ("attack");
		damageDealer.SetActive (true);
	}

	void endAttack()
	{
		Debug.Log ("stopattack");
		damageDealer.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		
	}
	void OnTriggerExit2D(Collider2D other) 
	{
		
	}
	void OnTriggerStay2D(Collider2D other) 
	{
		
	}

}
