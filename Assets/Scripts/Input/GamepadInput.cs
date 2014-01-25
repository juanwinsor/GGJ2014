using UnityEngine;
using System.Collections;
using XInputDotNetPure;

/********************************************************************************original, mostly working with slight locks in the 45 degrees */
public class _LeftThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			float dist = Vector2.Distance(new Vector2(_stateInfo[playerIndex].ThumbSticks.Left.X, _stateInfo[playerIndex].ThumbSticks.Left.Y), Vector2.zero);

			if(dist < _deadZone)
			{
				return Vector2.zero;
			}
			else
			{
				return new Vector2(_stateInfo[playerIndex].ThumbSticks.Left.X, _stateInfo[playerIndex].ThumbSticks.Left.Y);
			}
		}
	}
}


public class _RightThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			//if both analog axis are in the deadzone then return 0
			//if(Mathf.Abs(_stateInfo[playerIndex].ThumbSticks.Right.X) < _deadZone && Mathf.Abs(_stateInfo[playerIndex].ThumbSticks.Right.Y) < _deadZone)
			if(Mathf.Abs(_stateInfo[playerIndex].ThumbSticks.Right.X + _stateInfo[playerIndex].ThumbSticks.Right.Y) < _deadZone)
			{
				return Vector2.zero;
			}
			else
			{
				return new Vector2(_stateInfo[playerIndex].ThumbSticks.Right.X, _stateInfo[playerIndex].ThumbSticks.Right.Y);
			}
		}
	}
}
/****************************************************************************************************************************************************/

/********************************************************************XNA implementation, doesn't seem different from the original
public class _LeftThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			float x = _stateInfo[playerIndex].ThumbSticks.Left.X;
			float y = _stateInfo[playerIndex].ThumbSticks.Left.Y;
			float num1 = (float) Mathf.Sqrt((x * x + y * y));
			float num2 = GamepadInput.ApplyLinearDeadZone(num1, 1f, (float) _deadZone);
			float num3 = (double) num2 > 0.0 ? num2 / num1 : 0.0f;
			
			Vector2 result = Vector2.zero;
			result.x = Mathf.Clamp((float) x * num3, -1f, 1f);
			result.y = Mathf.Clamp((float) y * num3, -1f, 1f);
			
			return result;
		}
	}
}


public class _RightThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			float x = _stateInfo[playerIndex].ThumbSticks.Right.X;
			float y = _stateInfo[playerIndex].ThumbSticks.Right.Y;
			float num1 = (float) Mathf.Sqrt((x * x + y * y));
			float num2 = GamepadInput.ApplyLinearDeadZone(num1, 1f, (float) _deadZone);
			float num3 = (double) num2 > 0.0 ? num2 / num1 : 0.0f;
			
			Vector2 result = Vector2.zero;
			result.x = Mathf.Clamp((float) x * num3, -1f, 1f);
			result.y = Mathf.Clamp((float) y * num3, -1f, 1f);
			
			return result;
		}
	}
}
*/


/**********************************************************Renaud's implementation
public class _LeftThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			float x = _stateInfo[playerIndex].ThumbSticks.Left.X;
			float y = _stateInfo[playerIndex].ThumbSticks.Left.Y;
			
			Vector2 val = new Vector2(x, y);
			float magnitude = val.magnitude;
			Vector2 direction = val / (magnitude == 0 ? 1 : magnitude);
			
			float normalizedMagnitude = 0.0f;
			if(magnitude - _deadZone > 0)
				normalizedMagnitude = Mathf.Min((magnitude - _deadZone) / (short.MaxValue - _deadZone), 1);
			
			return direction * normalizedMagnitude;
		}
	}
}


public class _RightThumbstickProperty
{
	public float _deadZone = 0.3f;
	public GamePadState[] _stateInfo = new GamePadState[4];
	
	public Vector2 this[int playerIndex]
	{
		get
		{
			float x = _stateInfo[playerIndex].ThumbSticks.Right.X;
			float y = _stateInfo[playerIndex].ThumbSticks.Right.Y;
			
			Vector2 val = new Vector2(x, y);
			float magnitude = val.magnitude;
			Vector2 direction = val / (magnitude == 0 ? 1 : magnitude);
			
			float normalizedMagnitude = 0.0f;
			if(magnitude - _deadZone > 0)
				normalizedMagnitude = Mathf.Min((magnitude - _deadZone) / (short.MaxValue - _deadZone), 1);
			
			return direction * normalizedMagnitude;
		}
	}
}
*/



public class GamepadInput {
	/********************************************************************************************
	 GamepadInput - singleton
	 usage:
	 
	 where playerIndex = 0 - 3
	 
	 //button inputs
	 if(GamepadInput.Instance.state[playerIndex].Button.Start == XInputDotNetPure.ButtonState.Pressed)
	 {
	 	...
 	 }
	 
	 //analog inputs
	 float leftTriggerValue = GamepadInput.Instance.state[playerIndex].Triggers.Left;
	 
	********************************************************************************************/
	
	public _LeftThumbstickProperty LeftThumbstick = new _LeftThumbstickProperty();
	public _RightThumbstickProperty RightThumbstick = new _RightThumbstickProperty();
	
	
	private static GamepadInput m_Instance = null;

	public GamePadState[] state = new GamePadState[4];
	public GamePadState[] previousState = new GamePadState[4];
	
	public static GamepadInput Instance
	{
		get
		{
			if(m_Instance == null)
			{
				m_Instance = new GamepadInput();
			}
			
			return m_Instance;
		}
	}
	
	
	
	public GamepadInput()
	{
		reset();
	}
	
	public void reset()
	{
		for(int i = 0; i < state.Length; i++)
		{
			state[i] = GamePad.GetState((PlayerIndex)i);
		}
	}
	
	public void updateInput()
	{
		//testing thumbstick circular deadzone axis
		//Debug.Log(this.LeftThumbstick[0].x + " : " + this.LeftThumbstick[0].y);
		//Debug.Log(this.RightThumbstick[0].x + " : " + this.RightThumbstick[0].y);
		
		
		//get the current state for gamepad input
		for(int i = 0; i < state.Length; i++)
		{
			if(GamePad.GetState((PlayerIndex)i).IsConnected)
			{
				//store previous state
				previousState[i] = state[i];
				//get current state
				state[i] = GamePad.GetState((PlayerIndex)i, GamePadDeadZone.None);
				
				LeftThumbstick._stateInfo = state;
				RightThumbstick._stateInfo = state;
			}
		}
	}
	
	public void setVibration(int playerIndex, float left, float right)
	{
		GamePad.SetVibration((PlayerIndex)playerIndex, left, right);
	}
	
	
	
	public static float ApplyLinearDeadZone(float value, float maxValue, float deadZoneSize)
	{
		if ((double) value < -(double) deadZoneSize)
		{
			value += deadZoneSize;
		}
		else
		{
			if ((double) value <= (double) deadZoneSize)
			return 0.0f;
			value -= deadZoneSize;
		}
		
		return Mathf.Clamp(value / (maxValue - deadZoneSize), -1f, 1f);
	}

}
