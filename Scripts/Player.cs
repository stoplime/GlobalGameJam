using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;
	private Vector2 vel;

	// Use this for initialization
	void Start () {
		vel = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManage.IsPaused)
		{
			Controls();
			transform.Translate(vel);
		}
	}

	public void Controls() {
		if (Input.GetKey(GameManage.keyProfile["right"]))
		{
			vel.x = Time.deltaTime * speed;
		}
		else if (Input.GetKey(GameManage.keyProfile["left"]))
		{
			vel.x = -Time.deltaTime * speed;
		}
		else
		{
			vel.x = 0;
		}

		if (Input.GetKey(GameManage.keyProfile["forward"]))
		{
			vel.y = Time.deltaTime * speed;
		}
		else if (Input.GetKey(GameManage.keyProfile["backward"]))
		{
			vel.y = -Time.deltaTime * speed;
		}
		else
		{
			vel.y = 0;
		}
	}
}
