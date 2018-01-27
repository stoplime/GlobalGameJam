using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Help{
	public static float getDist2D(Vector3 pos1, Vector3 pos2){
		float x = pos2.x-pos1.x;
		float y = pos2.y-pos1.y;
		return Mathf.Sqrt(x*x+y*y);
	}
}
