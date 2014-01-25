using UnityEngine;
using System.Collections;

public class testInput : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) 
		{
			animator.SetTrigger("attack");
		}
	}
}
