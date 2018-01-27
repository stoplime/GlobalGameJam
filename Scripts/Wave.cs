using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	public Shader shader;
	public Color color;
	public float frequency;
	public float thickness;
	public float offset;

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();
        rend.material = new Material(shader);
		rend.material.color = color;
		rend.material.SetFloat("_Frequency", frequency);
		rend.material.SetFloat("_Thickness", thickness);
		rend.material.SetFloat("_Offset", offset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
