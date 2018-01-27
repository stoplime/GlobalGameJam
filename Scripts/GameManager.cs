using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManage {
	public static bool IsPaused = false;

	public static GameObject player;
	
	public static Dictionary<string, KeyCode> keyProfile = new Dictionary<string, KeyCode>()
	{
		{"forward", KeyCode.W},
		{"backward", KeyCode.S},
		{"left", KeyCode.A},
		{"right", KeyCode.D},
		{"fire", KeyCode.Mouse0}
	};

}
