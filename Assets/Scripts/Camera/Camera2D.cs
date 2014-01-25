using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public float pixelsPerUnit = 100.0f;

	public float zoom = 1.0f;

	public GameObject followTarget = null;
	public bool followSmoothing = false;
	public float followSmoothingAmount = 0.01f;

	// Use this for initialization
	void Start () {

	}

	void Awake()
	{
		//initial camera zoom 1:1 pixel/unit ratio
		camera.orthographicSize = (Screen.height / pixelsPerUnit / 2.0f) * zoom;
		//set origin at bottom left corner
		camera.transform.position = new Vector3((Screen.width / pixelsPerUnit / 2.0f) * zoom, camera.orthographicSize, -10);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LateUpdate()
	{
		camera.orthographicSize = (Screen.height / pixelsPerUnit / 2.0f) * zoom;

		if(followTarget != null)
		{
			Vector3 target = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10);

			if(followSmoothing == true)
			{
				camera.transform.position = Vector3.Lerp(camera.transform.position, target, Mathf.SmoothStep(0f, 1f, followSmoothingAmount * Time.deltaTime));
			}
			else
			{
				camera.transform.position = target;
			}
		}
	}
}
