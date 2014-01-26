using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Animator animator;

	float speed = 2.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//MoveDir (1);
	}

	public void MoveDir(int dir)
	{
		Vector2 direction = new Vector2(0,0);
		switch(dir)
		{
		case 1:
			direction = new Vector2(0,1);
			animator.SetFloat("velocity", 1.0f);
			//Rotate Top
			if(this.gameObject.transform.rotation != Quaternion.Euler(new Vector3(0,0,0)))
			{
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
			break;
		case 2:
			direction = new Vector2(0,-1);
			//direction = new Vector2(0,1);
			animator.SetFloat("velocity", 1.0f);
			if(this.gameObject.transform.rotation != Quaternion.Euler(new Vector3(0,0,180)))
			{
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
			}
			break;
		case 3:
			direction = new Vector2(-1,0);
			//direction = new Vector2(0,1);
			animator.SetFloat("velocity", 1.0f);
			if(this.gameObject.transform.rotation != Quaternion.Euler(new Vector3(0,0,90)))
			{
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
			}
			break;
		case 4:
			direction = new Vector2(1,0);
			//direction = new Vector2(0,1);
			animator.SetFloat("velocity", 1.0f);
			if(this.gameObject.transform.rotation != Quaternion.Euler(new Vector3(0,0,270)))
			{
				this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
			}
			break;
		default:
			direction = Vector2.zero;
			animator.SetFloat("velocity", 0);
			break;
			
		}
		
		gameObject.rigidbody2D.velocity = direction * speed;
	}
}
