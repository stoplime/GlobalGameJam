using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	public float getMaxWaveEffectDist(){
		return transform.localScale[0] * getMaterial().GetFloat("_MaxRadius");
	}

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
