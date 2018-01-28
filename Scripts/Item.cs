using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool pickedUp = false;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
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