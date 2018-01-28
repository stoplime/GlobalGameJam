using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager {
	public static bool IsPaused = false;

	public static GameObject player;

	public static List<GameObject> dots = new List<GameObject>();

	public static List<GameObject> droppedItems = new List<GameObject>();

	public static List<GameObject> pickedUpItems = new List<GameObject>();

    public static Dictionary<string, KeyCode> keyProfile = new Dictionary<string, KeyCode>()
    {
        {"forward", KeyCode.W},
        {"backward", KeyCode.S},
        {"left", KeyCode.A},
        {"right", KeyCode.D},
        {"fire", KeyCode.Mouse0},
        {"ultimate", KeyCode.LeftShift},

        {"forward_2", KeyCode.UpArrow},
        {"backward_2", KeyCode.DownArrow},
        {"left_2", KeyCode.LeftArrow },
        {"right_2", KeyCode.RightArrow }
	};

}
