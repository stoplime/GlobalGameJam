using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	public Shader shader;
	public Color color;
	public Material startMaterial;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
        rend.material = new Material(startMaterial);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Material getMaterial() {
		return rend.material;
	}

	public void setMaterial(Material mat) {
		rend.material = mat;
	}
}
