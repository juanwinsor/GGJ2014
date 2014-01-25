using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveDir(int dir)
	{
		Vector2 direction = new Vector2(0,0);
		switch(dir)
		{
		case 1:
			direction = new Vector2(0,1);
			break;
		case 2:
			direction = new Vector2(0,-1);
			break;
		case 3:
			direction = new Vector2(-1,0);
			break;
		case 4:
			direction = new Vector2(1,0);
			break;
		default:
			direction = Vector2.zero;
			break;
			
		}
		
		this.gameObject.rigidbody2D.AddForce(direction * 30.0f);
	}
}
