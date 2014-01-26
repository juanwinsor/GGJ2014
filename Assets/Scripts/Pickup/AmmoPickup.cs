using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
		
	//public AmmoSpawner ammoSpawnerScript;

	float minSize = 0.1f;
	float maxSize = 0.2f;
	float size = 0.15f;
	float speed = 0.3f;

	bool isGrowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isGrowing) 
		{
			size += speed * Time.deltaTime;
			if(size > maxSize)
			{
				isGrowing = false;
			}
		}
		else
		{
			size -= speed * Time.deltaTime;
			if(size < minSize)
			{
				isGrowing = true;
			}
		}
		this.gameObject.transform.localScale = new Vector3(size,size,1);
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("AMMOHIT");
		if (collider.gameObject.tag == "Beast" || collider.gameObject.tag == "Human") 
		{
			//Give the collider a bullet
			PlayerController pcs = collider.gameObject.GetComponent<PlayerController>();
			pcs.AmmoCount = 1;
			//destroy this game object.
			//ammoSpawnerScript.ammoOnScreen--;
			Destroy(this.gameObject);
		}
	}
}
