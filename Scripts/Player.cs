﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public const float FRICTION_CONSTANT = 2F;
    public const float FORCE = 0.25F;

    public float speed;     // the speed scalar
    private Vector2 vel;    // velocity vector
    private Vector2 acl;    // acceleration vector
    private Vector2 net;    // net force vector
    private Vector2 frc;    // actor force vector
    private Vector2 fri;    // friction vector

	// Use this for initialization
	void Start () {
		vel = Vector2.zero;
        acl = Vector2.zero;
        net = Vector2.zero;
        frc = Vector2.zero;
        fri = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManage.IsPaused)
		{
			Controls();
            calculateFriction();
            calculateNetForce();
            calculateVelocity();
            transform.Translate(vel);
		}
	}

    private void calculateVelocity()
    {
        vel.x += Time.deltaTime * net.x;
        vel.y += Time.deltaTime * net.y;
    }

    private void calculateFriction()
    {
        fri.x = FRICTION_CONSTANT * (vel.x/speed);
        fri.y = FRICTION_CONSTANT * (vel.y/speed);
    }

    private void calculateNetForce()
    {
        net.x = frc.x - fri.x;
        net.y = frc.y - fri.y;
    }

	public void Controls() {
		if (Input.GetKey(GameManage.keyProfile["right"]))
		{
            frc.x = FORCE;
			// vel.x = Time.deltaTime * speed;
		}
		else if (Input.GetKey(GameManage.keyProfile["left"]))
		{
            frc.x = -FORCE;
			// vel.x = -Time.deltaTime * speed;
		}
		else
		{
            frc.x = 0;
			// vel.x = 0;
		}

		if (Input.GetKey(GameManage.keyProfile["forward"]))
		{
            frc.y = FORCE;
			//vel.y = Time.deltaTime * speed;
		}
		else if (Input.GetKey(GameManage.keyProfile["backward"]))
		{
            frc.y = -FORCE;
			//vel.y = -Time.deltaTime * speed;
		}
		else
		{
            frc.y = 0;
			// vel.y = 0;
		}
	}
}
