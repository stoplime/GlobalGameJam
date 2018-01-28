using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColor : MonoBehaviour {

	public Color target;

	public float threshold = 20f;

	public GameObject prefab;

	private Renderer rend;
	private Material mat;

	private bool isFading = false;

	// Use this for initialization
	void Start () {
		rend = GetComponentInParent<Renderer>();
		mat = rend.material;
		target.a = 1f;
		GetComponent<Renderer>().material.color = target;
	}
	
	// Update is called once per frame
	void Update () {
		print(isFading);
		if (isFading)
		{
			Color currentColor = GetComponent<Renderer>().material.color;
			currentColor.a -= 0.5f * Time.deltaTime;
			GetComponent<Renderer>().material.color = currentColor;
			Color dotColor = GetComponentInParent<Renderer>().material.color;
			dotColor.a = currentColor.a;
			GetComponentInParent<Renderer>().material.color = dotColor;
			print(GetComponentInParent<Renderer>().material.color);
			if (currentColor.a <= 0)
			{
				Destroy(transform.parent.gameObject);
			}
		}
		else
		{
			if (Help.ColorThresh(mat.color, target, threshold))
			{
				// The color has reached the target
				// fade to the background and spawn a pickup item
				isFading = true;
				// Instantiate(prefab, transform.position, Quaternion.identity);
			}
		}
	}
}
