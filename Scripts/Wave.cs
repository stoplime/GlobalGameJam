using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
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
