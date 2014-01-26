using UnityEngine;
using System.Collections;

public class BeastAttackFlicker : MonoBehaviour {

	Timer flickerTotalTime = new Timer (3.0f);
	Timer flickerChange;
	bool roomLit = false;
	int flickerChangeCount = 0;
	bool flickerDone = false;
	bool flickerTotalDone = true;
	
	public Sprite lightON;
	public Sprite lightOFF;
	public SpriteRenderer levelRenderer;
	public GameObject lightPath;

	public Color lightDefault = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	public Color lightMaxFlicker = new Color(0.2f, 0.2f, 0.2f, 1.0f);
	public Color lightMinFlicker = new Color(0.1f, 0.1f, 0.1f, 1.0f);

	// Use this for initialization
	void Start () {
		PlayLightFlicker ();
	}

	public void PlayLightFlicker()
	{
		//reset variables
		roomLit = false;
		flickerChangeCount = 0;
		flickerDone = false;
		flickerTotalDone = false;


		flickerTotalTime.Start ();
		
		flickerChange = new Timer (0.3f);
		flickerChange.Start ();
		roomLit = false;
		RenderSettings.ambientLight = lightMinFlicker;
	}


	
	// Update is called once per frame
	void Update () {
		if(flickerTotalDone == false)
		{
			if (flickerChange.Done && flickerDone == false) 
			{
				if(roomLit == true)
				{
					RenderSettings.ambientLight = lightMinFlicker;
					flickerChange.intervalTime = 0.3f;
					flickerChange.Start();
					roomLit = false;
					flickerChangeCount++;
					//DARK
					levelRenderer.sprite = lightOFF;
					lightPath.SetActive(true);
				}
				else
				{
					RenderSettings.ambientLight = lightDefault;
					flickerChange.intervalTime = 0.1f;
					flickerChange.Start();
					roomLit = true;
					flickerChangeCount++;
					//LIGHT
					levelRenderer.sprite = lightON;
					lightPath.SetActive(false);
				}
				
			}
			
			if(flickerChangeCount == 5)
			{
				flickerDone = true;
				RenderSettings.ambientLight = lightMinFlicker;
				flickerChange.Stop();
				roomLit = false;
				//DARK
				levelRenderer.sprite = lightOFF;
				lightPath.SetActive(true);
			}
			
			if(flickerTotalTime.Done)
			{
				flickerTotalDone = true;
				RenderSettings.ambientLight = lightDefault;
				roomLit = true;
				//LIGHT
				levelRenderer.sprite = lightON;
				lightPath.SetActive(false);
			}
		}
	}
}
