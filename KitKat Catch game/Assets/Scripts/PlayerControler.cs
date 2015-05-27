using UnityEngine;
using System.Collections;


public class PlayerControler : MonoBehaviour {
	public float speed = 0.5f;
	public Camera cam;
	Rigidbody2D rgbd2;
	float maxwidth;
	Renderer rend;
	//public Rigidbody2D rigidbody2d;
	// Use this for initialization
	void Start () {
		if(cam==null) cam=Camera.main;
		rgbd2= this.gameObject.GetComponent<Rigidbody2D>();
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		rend = GetComponent<Renderer>();
		float playerWidth = rend.bounds.extents.x;
		maxwidth = targetWidth.x-playerWidth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(Input.GetAxis("Horizontal"),0,0);

		Vector3 rawPos = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPos = new Vector3 (rawPos.x, 0.0f, 0.0f);
		float targetWidth = Mathf.Clamp (targetPos.x, -maxwidth, maxwidth);
		targetPos = new Vector3 (targetWidth, targetPos.y, targetPos.z);
		rgbd2.MovePosition (targetPos);
	}
}
