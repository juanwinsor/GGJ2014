using UnityEngine;
using System.Collections;

public class DeathMarker : MonoBehaviour {

	float thesize = 0.1f;
	float speed = 1.0f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		thesize += speed * Time.deltaTime;
		this.gameObject.transform.localScale = new Vector3 (thesize, thesize, 1.0f);
	
	}
}
