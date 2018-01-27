using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEntity : MonoBehaviour {

	private float repel;
	private Vector3 color;
	private string emot;
	private float freq;
	private float ampl;
	private float noise;

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
		Wave thisWave = GetComponent<Wave>();
		
	}

	public void checkCollision(){
		for (int i = 0; i < GameManager.dots.Count; i++)
		{
			float dist = Help.getDist2D(trasform.position, GameManager.dots[i].trasform.position);
			if (dist < GameManager.dots[i].GetComponent<Wave>().MaxWaveEffectDist)
			{
				// apply collision based on distance
				applyColorMix(dist, GameManager.dots[i].GetComponent<Wave>());
			}
		}
	}

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		
	}
}
