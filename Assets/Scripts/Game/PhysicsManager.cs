using UnityEngine;
using System.Collections;

public class PhysicsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (9, 9);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
