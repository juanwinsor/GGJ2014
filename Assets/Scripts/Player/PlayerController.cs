using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

	public int playerNumber = -1;
	public Movement movementScript;
	//PlayerIndex controllerNumber;

	// Use this for initialization
	void Start () {
		/*switch (playerNumber) 
		{
		default:
			controllerNumber = PlayerIndex.One;
			break;
		case 1:
			controllerNumber = PlayerIndex.One;
			break;
		case 2:
			controllerNumber = PlayerIndex.Two;
			break;
		case 3:
			controllerNumber = PlayerIndex.Three;
			break;
		case 4:
			controllerNumber = PlayerIndex.Four;
			break;

		}*/
	}
	
	// Update is called once per frame
	void Update () {

		if (playerNumber != -1) 
		{
			if(GamepadInput.Instance.state[playerNumber].IsConnected)
			{
				if(GamepadInput.Instance.state[playerNumber].DPad.Up == ButtonState.Pressed && GamepadInput.Instance.previousState[playerNumber].DPad.Up != GamepadInput.Instance.state[playerNumber].DPad.Up)
				{
					movementScript.MoveDir(1);
				}
				if(GamepadInput.Instance.state[playerNumber].DPad.Down == ButtonState.Pressed && GamepadInput.Instance.previousState[playerNumber].DPad.Down != GamepadInput.Instance.state[playerNumber].DPad.Down)
				{
					movementScript.MoveDir(2);
				}
				if(GamepadInput.Instance.state[playerNumber].DPad.Left == ButtonState.Pressed && GamepadInput.Instance.previousState[playerNumber].DPad.Left != GamepadInput.Instance.state[playerNumber].DPad.Left)
				{
					movementScript.MoveDir(3);
				}
				if(GamepadInput.Instance.state[playerNumber].DPad.Right == ButtonState.Pressed && GamepadInput.Instance.previousState[playerNumber].DPad.Right != GamepadInput.Instance.state[playerNumber].DPad.Right)
				{
					movementScript.MoveDir(4);
				}
				if(GamepadInput.Instance.state[playerNumber].DPad.Up == ButtonState.Released && GamepadInput.Instance.state[playerNumber].DPad.Down == ButtonState.Released && GamepadInput.Instance.state[playerNumber].DPad.Left == ButtonState.Released && GamepadInput.Instance.state[playerNumber].DPad.Right == ButtonState.Released)
				{
					movementScript.MoveDir(0);
				}
			}
		}


		/*
		GamePadState checkState = GamePad.GetState(controllerNumber);
		if (checkState.IsConnected) 
		{
			GamePadState state = GamePad.GetState(controllerNumber);

			//if(state.Buttons.
		}*/
	
	}
}
