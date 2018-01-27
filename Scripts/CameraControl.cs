using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	
	public GameObject player;

	private float borderSize;

	private Camera cam;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		if (player == null)
		{
			player = GameObject.FindWithTag("Player");
		}
		cam = GetComponent<Camera>();
		offset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		// Vector3 playerScreenPos = cam.WorldToScreenPoint(player.transform.position);
		// if (playerScreenPos.x < borderSize)
		// {
			
		// }
		Vector3 offset = player.transform.position;
		offset.z = -10f;
		transform.position = offset;
	}
}
