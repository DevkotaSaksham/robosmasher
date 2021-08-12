using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcereceiver : MonoBehaviour
{
    public float deceleration = 3;
    public float mass = 5;

    private Vector3 intensity;
    private CharacterController character;




    void Start()
    {
        intensity = Vector3.zero;
        character = GetComponent<CharacterController>();
        
    }



    void Update()
    {
        if(intensity.magnitude>0.2f)
        {
            character.Move(intensity * Time.deltaTime);
        }
        intensity = Vector3.Lerp(intensity, Vector3.zero, deceleration * Time.deltaTime);
    }


    public void addforce(Vector3 direction, float force)
    {

        intensity = intensity + direction.normalized * force / mass;
    }
}




