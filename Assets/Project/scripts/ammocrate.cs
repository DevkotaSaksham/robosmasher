using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammocrate : MonoBehaviour
{

    public GameObject container;
    public float rotationspeed = 180f;
    public int AmmoAddUp = 10;

   

   
    void Update()
    {
        container.transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);
    }
}
