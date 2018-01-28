using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEntity : MonoBehaviour {

	public float colorInfluence = 0.2f;

    private float timer;

    private float nextTime;

	private float repel;
	private Vector3 color;
	private string emot;
	private float freq;
	private float ampl;
	private float noise;

    private Vector2 force;

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
				applyColorMix(dist, wave);
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
        force = Vector2.zero;
		GameManager.dots = GameObject.FindGameObjectsWithTag("dots");
        force = Random.insideUnitCircle;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		checkCollision();
        timer += Time.deltaTime;

        if (timer >= nextTime)
        {
            force = Random.insideUnitCircle * 2;
            force = Vector2.ClampMagnitude(force, .25F);
        }
	}
}
