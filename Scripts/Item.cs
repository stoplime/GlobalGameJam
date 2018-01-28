using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public bool pickedUp = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    void Update () {
        transform.Rotate(new Vector3(0, 0, 60)*Time.deltaTime);
    }

    

}
