using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public bool pickedUp = false;

    private float rotationSpeed;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rotationSpeed = 60.0F;
    }

    void CheckDistance()
    {
        const float _A = 12.2F;
        const float _B = 10F;
        const float _C = 3.5F;
        //print(GameManager.player);
        float distance = Help.getDist2D(transform.position, GameManager.player.transform.position) * 2;

        rotationSpeed = -_A * Help.getTanH(distance/_B - _C) + 61F + _A;
    }

    void Update () {
        CheckDistance();
        transform.Rotate(new Vector3(0F, 0F, rotationSpeed)*Time.deltaTime);
        //CheckDistance();
    }

    

}
