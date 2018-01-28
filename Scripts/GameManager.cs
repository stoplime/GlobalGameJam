using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {
	public static bool IsPaused = false;

	public static GameObject player;

	public static List<GameObject> dots = new List<GameObject>();
	// private static findDots = GameObject.FindGameObjectsWithTag("dots");
	// for (int i = 0; i < findDots.Length; i++)
	// {
	// 	dots.Add(findDots[i]);
	// }
	
	public static Dictionary<string, KeyCode> keyProfile = new Dictionary<string, KeyCode>()
	{
		{"forward", KeyCode.W},
		{"backward", KeyCode.S},
		{"left", KeyCode.A},
		{"right", KeyCode.D},
		{"fire", KeyCode.Mouse0},
        {"ultimate", KeyCode.LeftShift}
	};

}
