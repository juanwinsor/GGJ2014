using UnityEngine;
using System.Collections;

public class ResetWinScreen : MonoBehaviour {

	Timer inputTimer = new Timer(5.0f);

	// Use this for initialization
	void Start () {
		inputTimer.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		GamepadInput.Instance.updateInput ();


		if (inputTimer.Done) 
		{
			for (int i =0; i < 4; i++) {
				if (GamepadInput.Instance.state [i].IsConnected == true) {
					if (GamepadInput.Instance.state [i].Buttons.A == XInputDotNetPure.ButtonState.Pressed) 
					{
						Application.LoadLevel ("game");
					}
				}
			}
		}
	}
}
