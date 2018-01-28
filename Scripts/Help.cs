using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Help{
    public const float _E = 2.71828F;
    public static float getDist2D(Vector3 pos1, Vector3 pos2){
		float x = pos2.x-pos1.x;
		float y = pos2.y-pos1.y;
		return Mathf.Sqrt(x*x+y*y);
	}

	public static bool ColorThresh(Color sample, Color target, float threshold){
		bool isRedGood = (sample.r >= (target.r - threshold)) && (sample.r <= (target.r + threshold));
		bool isGreenGood = (sample.g >= (target.g - threshold)) && (sample.g <= (target.g + threshold));
		bool isBlueGood = (sample.b >= (target.b - threshold)) && (sample.b <= (target.b + threshold));
		return isRedGood && isGreenGood && isBlueGood;
	}

    public static float getTanH(float x)
    {
        return (Mathf.Pow(_E, 2F * x) - 1F) / (Mathf.Pow(_E, 2F * x) + 1F);
    }
}
