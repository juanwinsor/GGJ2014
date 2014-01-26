using UnityEngine;
using System.Collections;

public class ResetWinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		GamepadInput.Instance.updateInput ();

		for (int i =0; i < 4; i++) 
		{
			if(GamepadInput.Instance.state[i].IsConnected == true)
			{
				if(GamepadInput.Instance.state[i].Buttons.A == XInputDotNetPure.ButtonState.Pressed)
				{
					Application.LoadLevel("game");
				}
			}
		}




	}
}
