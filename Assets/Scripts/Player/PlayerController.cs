﻿using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class PlayerController : MonoBehaviour {
	
	public int playerNumber = -1;
	public Movement movementScript;
	public Animator animator;
	public GameObject weapon;

	public bool isBeastly;
	
	
	public int AmmoCount = 1;
	
	float rumbleTimer = 0.0f;
	float rumbleLength = 1.0f;
	bool isRumbling = true;
	Timer rumXTimer = new Timer(1);
	Timer rumYTimer = new Timer(1);
	Timer rumBTimer = new Timer(1);
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
		
		if (rumXTimer.Done && rumX == true) 
		{
			if(playerNumber == 0)
			{
				GamepadInput.Instance.setVibration(1,0.0f,0.0f);
			}
			else if (playerNumber == 1 || playerNumber == 2 || playerNumber == 3)
			{
				GamepadInput.Instance.setVibration(0,0.0f,0.0f);
			}
		}
		
		if (rumXTimer.Done && rumX == true) 
		{
			if(playerNumber == 0 || playerNumber == 1)
			{
				GamepadInput.Instance.setVibration(2,0.0f,0.0f);
			}
			else if (playerNumber == 2  || playerNumber == 3)
			{
				GamepadInput.Instance.setVibration(1,0.0f,0.0f);
			}
		}
		
		if (rumXTimer.Done && rumX == true) 
		{
			if(playerNumber == 0 || playerNumber == 1 || playerNumber == 2)
			{
				GamepadInput.Instance.setVibration(3,0.0f,0.0f);
			}
			else if (playerNumber == 3)
			{
				GamepadInput.Instance.setVibration(2,0.0f,0.0f);
			}
		}
		
		if (playerNumber != -1) 
		{
			if(GamepadInput.Instance.state[playerNumber].IsConnected)
			{
				if(GamepadInput.Instance.state[playerNumber].DPad.Up == ButtonState.Pressed)
				{
					movementScript.MoveDir(1);
					animator.SetFloat("velocity", 1.0f);
					
				}
				else if(GamepadInput.Instance.state[playerNumber].DPad.Down == ButtonState.Pressed)
				{
					movementScript.MoveDir(2);
					animator.SetFloat("velocity", 1.0f);
					
				}
				else if(GamepadInput.Instance.state[playerNumber].DPad.Left == ButtonState.Pressed)
				{
					movementScript.MoveDir(3);
					animator.SetFloat("velocity", 1.0f);
					
				}
				else if(GamepadInput.Instance.state[playerNumber].DPad.Right == ButtonState.Pressed)
				{
					movementScript.MoveDir(4);
					animator.SetFloat("velocity", 1.0f);
					
				}
				else if((GamepadInput.Instance.state[playerNumber].DPad.Up == ButtonState.Released && GamepadInput.Instance.previousState[playerNumber].DPad.Up == ButtonState.Pressed) ||
				        (GamepadInput.Instance.state[playerNumber].DPad.Down == ButtonState.Released && GamepadInput.Instance.previousState[playerNumber].DPad.Down == ButtonState.Pressed) ||
				        (GamepadInput.Instance.state[playerNumber].DPad.Left == ButtonState.Released && GamepadInput.Instance.previousState[playerNumber].DPad.Left == ButtonState.Pressed) ||
				        (GamepadInput.Instance.state[playerNumber].DPad.Right == ButtonState.Released && GamepadInput.Instance.previousState[playerNumber].DPad.Right == ButtonState.Pressed ))
				{
					movementScript.MoveDir(0);
					animator.SetFloat("velocity", 0);
					
				}
				
				if (GamepadInput.Instance.state[playerNumber].Buttons.A == ButtonState.Pressed && GamepadInput.Instance.previousState[playerNumber].Buttons.A == ButtonState.Released) 
				{
					if( (AmmoCount > 0 && !isBeastly))
					{
						AmmoCount--;
						animator.SetTrigger("attack");
					}
					
					if(isBeastly)
					{
						animator.SetTrigger("attack");
					}
				}
				
				if(isBeastly)
				{
					if(GamepadInput.Instance.state[playerNumber].Buttons.X == ButtonState.Pressed && rumX == false)
					{
						if(playerNumber == 0)
						{
							GamepadInput.Instance.setVibration(1,50.0f,50.0f);
							rumXTimer.Start();
							rumX = true;
						}
						else if (playerNumber == 1 || playerNumber == 2 || playerNumber == 3)
						{
							GamepadInput.Instance.setVibration(0,50.0f,50.0f);
							rumXTimer.Start();
							rumX = true;
						}
					}
					if(GamepadInput.Instance.state[playerNumber].Buttons.Y == ButtonState.Pressed && rumY == false)
					{
						if(playerNumber == 0 || playerNumber == 1)
						{
							GamepadInput.Instance.setVibration(2,50.0f,50.0f);
							rumYTimer.Start();
							rumY = true;
						}
						else if (playerNumber == 2  || playerNumber == 3)
						{
							GamepadInput.Instance.setVibration(1,50.0f,50.0f);
							rumYTimer.Start();
							rumY = true;
						}
					}
					if(GamepadInput.Instance.state[playerNumber].Buttons.B == ButtonState.Pressed && rumB == false)
					{
						if(playerNumber == 0 || playerNumber == 1 || playerNumber == 2)
						{
							GamepadInput.Instance.setVibration(3,50.0f,50.0f);
							rumBTimer.Start();
							rumB = true;
						}
						else if (playerNumber == 3)
						{
							GamepadInput.Instance.setVibration(2,50.0f,50.0f);
							rumBTimer.Start();
							rumB = true;
						}
					}
					
				}
				
			}
		}
		
	}
}
