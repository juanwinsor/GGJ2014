using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class PlayerController : MonoBehaviour {

	public int playerNumber = -1;
	public Movement movementScript;
	public Animator animator;
	public bool isBeastly;


	float rumbleTimer = 0.0f;
	float rumbleLength = 1.0f;
	bool isRumbling = true;
	bool rumX = false;
	bool rumY = false;
	bool rumB = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (isRumbling == true) 
		{
			rumbleTimer += Time.deltaTime;
			if (rumbleTimer > rumbleLength) 
			{
				GamepadInput.Instance.setVibration(playerNumber,0,0);
				isRumbling = false;
			}
		}

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

				if (GamepadInput.Instance.state[playerNumber].Buttons.A == ButtonState.Pressed && GamepadInput.Instance.state[playerNumber].Buttons.A != GamepadInput.Instance.previousState[playerNumber].Buttons.A) 
				{
					animator.SetTrigger("attack");
				}

				if(isBeastly)
				{
					if(GamepadInput.Instance.state[playerNumber].Buttons.X == ButtonState.Pressed && rumX == false)
					{
						if(playerNumber == 0)
						{
							GamepadInput.Instance.setVibration(1,1.0f,1.0f);
						}
					}
					if(GamepadInput.Instance.state[playerNumber].Buttons.X == ButtonState.Pressed && rumY == false)
					{
						
					}
					if(GamepadInput.Instance.state[playerNumber].Buttons.X == ButtonState.Pressed && rumB == false)
					{
						
					}

				}

			}
		}
	
	}
}
