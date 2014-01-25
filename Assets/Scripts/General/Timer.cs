using UnityEngine;
using System.Collections;

public class Timer {
	public float intervalTime = 0;
	private float startTime = 0;
	private float finishTime = 0;
	public bool running = false;
	
	public bool Done
	{
		get
		{
			if(running)
			{
				if(Time.time > finishTime)
				{
					return true;
				}
				else
				{
					return false;
					running = false;
				}
			}
			else
			{
				return true;
			}
		}
	}
	
	public Timer(float time)
	{
		intervalTime = time;
	}
	
	public void Start()
	{
		running = true;
		startTime = Time.time;
		finishTime = startTime + intervalTime;
	}
	
	public void Stop()
	{
		running = false;
	}
}
