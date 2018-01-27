using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public const float FRICTION_CONSTANT = 2F;
    public const float FORCE = 0.25F;

    public float speed;     // the speed scalar
    private Vector2 vel;    // velocity vector
    // private Vector2 acl;    // acceleration vector
    private Vector2 net;    // net force vector
    private Vector2 frc;    // actor force vector
    private Vector2 fri;    // friction vector

	public Collider coll;
    void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody)
            other.attachedRigidbody.useGravity = false;
        
    }

	// Use this for initialization
	void Start () {
		coll = GetComponent<Collider>();
        coll.isTrigger = true;

		vel = Vector2.zero;
        // acl = Vector2.zero;
        net = Vector2.zero;
        frc = Vector2.zero;
        fri = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.IsPaused)
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

        if (frc.magnitude < 0.01 && vel.magnitude < 0.001) { vel.x = 0; vel.y = 0; }

        // Debug.Log("Velocity: " + vel.magnitude);
    }

    private void calculateFriction()
    {
        fri.x = FORCE * (vel.x/speed);
        fri.y = FORCE * (vel.y/speed);

        fri = Vector2.ClampMagnitude(fri, FORCE);
    }

    private void calculateNetForce()
    {
        net.x = frc.x - fri.x;
        net.y = frc.y - fri.y;

        net = Vector2.ClampMagnitude(net, FORCE);
    }

	public void Controls() {
        frc.x = 0;
        frc.y = 0;

		if (Input.GetKey(GameManager.keyProfile["right"]))
		{
            frc.x += FORCE;
			// vel.x = Time.deltaTime * speed;
		}

        if (Input.GetKey(GameManager.keyProfile["left"]))
		{
            frc.x -= FORCE;
			// vel.x = -Time.deltaTime * speed;
		}

		if (Input.GetKey(GameManager.keyProfile["forward"]))
		{
            frc.y += FORCE;
			//vel.y = Time.deltaTime * speed;
		}

        if (Input.GetKey(GameManager.keyProfile["backward"]))
		{
            frc.y -= FORCE;
			//vel.y = -Time.deltaTime * speed;
		}

        frc = Vector2.ClampMagnitude(frc, FORCE);
	}
}
