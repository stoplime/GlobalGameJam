using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEntity : MonoBehaviour {
    public bool isPlayer = false;

    public const float FORCE = 0.25F;
    public const float speed = 0.2F;
	public float colorInfluence = 0.2f;

	public bool isBeacon = false;

    private Vector2 velocity;

    private bool isMoving;
	private float timer;
	private float nextTime;

	private float repel;
	private Vector3 color;
	private string emot;
	private float freq;
	private float ampl;
	private float noise;

    private Vector2 force;
    private Vector2 friction;
    private Vector2 net;

	void getRepelStrength(){

	}

	void getColor(){
		//angry.color(255,25,75) and (175, 0, 75)
		//sad.color(50, 50, 175) and (25, 25, 125)
		//fear.color(175, 255, 100) and (100, 175, 100)
	}

	void transition(){
		
		//calculates distance from another dot to determine rate of change to color of close dot
		//	if(distance<tooFar from otherDot){ return dot.rgb , return otherDot.rgb
		//	dot.transition*(distance-tooFar) , otherDot.transision*(distance-tooFar)}
	}

	public void applyColorMix(float dist, Wave otherWave){
		Wave thisWave = GetComponentsInChildren<Wave>()[0];
		Material thisMat = thisWave.getMaterial();
		Material otherMat = otherWave.getMaterial();
		Renderer rend = GetComponent<Renderer>();
		Material thisDotMat = rend.material;
		float colorLerp = (-dist/otherWave.getMaxWaveEffectDist()+1) * otherMat.GetFloat("_Frequency") * colorInfluence;
		thisMat.color = Color.Lerp(thisMat.color, otherMat.color, colorLerp);
		thisDotMat.color = Color.Lerp(thisDotMat.color, otherMat.color, colorLerp);
		print("color mixing");
	}

	public void checkCollision(){
		for (int i = 0; i < GameManager.dots.Length; i++)
		{
			float dist = Help.getDist2D(transform.position, GameManager.dots[i].transform.position);
			Wave wave = GameManager.dots[i].GetComponentsInChildren<Wave>()[0];
			// print(GameManager.dots[i].transform.position);
			// print(wave.getMaxWaveEffectDist());
			if (wave != null && dist < wave.getMaxWaveEffectDist())
			{
				// apply collision based on distance
				if (!isBeacon)
				{
					applyColorMix(dist, wave);
				}
			}
		}
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
        timer = 0.0F;
        isMoving = false;
        nextTime = Random.value * 2;
        velocity = Vector2.zero;
        force = Vector2.zero;
        friction = Vector2.zero;
        net = Vector2.zero;
		GameManager.dots = GameObject.FindGameObjectsWithTag("dots");
        force = Random.insideUnitCircle;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
        if (!GameManager.IsPaused)
        {
            if (!isPlayer)
            {
                checkCollision();
                timer += Time.deltaTime;

                if (timer >= nextTime)
                {
                    if (!isMoving)
                    {
                        force = Random.insideUnitCircle * 2;
                        force = Vector2.ClampMagnitude(force, FORCE);

                        isMoving = true;

                        nextTime = Random.value * 0.5F;
                    }
                    else
                    {
                        force = Vector2.zero;
                        isMoving = false;
                        nextTime = Random.value * 2;
                    }
                }

                calculateFriction();
                calculateNetForce();
                calculateVelocity();

                transform.Translate(velocity);
            }
        }
	}

    public void calculateFriction()
    {
        friction.x = FORCE * (velocity.x / speed);
        friction.y = FORCE * (velocity.y / speed);

        friction = Vector2.ClampMagnitude(friction, FORCE);
    }

    public void calculateNetForce()
    {
        net.x = force.x - friction.x;
        net.y = force.y - friction.y;

        net = Vector2.ClampMagnitude(net, FORCE);
    }

    public void calculateVelocity()
    {
        velocity.x += Time.deltaTime * net.x;
        velocity.y += Time.deltaTime * net.y;

        if (friction.magnitude < 0.01 && velocity.magnitude < 0.001) { velocity.x = 0; velocity.y = 0; }

        // Debug.Log("Velocity: " + vel.magnitude);
    }
}
