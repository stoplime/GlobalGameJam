using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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

        //rotationSpeed = -_A * Help.getTanH(distance/_B - _C) + 61F + _A;
    }

    void Update () {
        CheckDistance();
        transform.Rotate(new Vector3(0F, 0F, rotationSpeed)*Time.deltaTime);
        //CheckDistance();
    }

   // private void Start()
   // {
       // Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Vector3 itemPos = GameObject.FindGameObjectWithTag("Item").transform.position;

       // float distance = Vector3.Distance(playerPos, itemPos);
      //  if (distance < 1)
      //  {
           // rotateTransform.RotateAround(playerPos, Vector3.up, 2 * Time.deltaTime);
          //  transform.RotateAround(itemPos, playerPos, 20 * Time.deltaTime);

            //Vector3 relativePos = (playerPos + new Vector3(0, 1.5f, 0)) - transform.position;
            // Quaternion rotation = Quaternion.LookRotation(relativePos);

            // Quaternion current = transform.localRotation;

            //  transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
            //   transform.Translate(0, 0, 3 * Time.deltaTime);
      //  } 
   // }
}