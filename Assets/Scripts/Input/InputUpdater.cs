using UnityEngine;
using System.Collections;

public class InputUpdater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GamepadInput.Instance.updateInput();
	
	}
}
