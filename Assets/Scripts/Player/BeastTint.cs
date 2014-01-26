using UnityEngine;
using System.Collections;

public class BeastTint : MonoBehaviour {

	Timer turbo = new Timer(90);

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
		if (turbo.Done) {
			GetComponent<SpriteRenderer>().color = Color.red;
				}
	}
}
