using UnityEngine;
using System.Collections;

public class BeastGrowth : MonoBehaviour {

	Timer turboTimer = new Timer(90);

	// Use this for initialization
	void Start () {
		turboTimer.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		if (turboTimer.Done) {
			this.gameObject.transform.localScale = new Vector3(1.5f,1.5f,1);
				}
	
	}
}
