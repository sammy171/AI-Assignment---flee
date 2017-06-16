using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIAgent : MonoBehaviour
{
    //public
    public Vector3 force;
    public Vector3 velocity;
    public float maxVelocity = 100f;

    private List<SteeringBehaviour> behaviours;



    // Use this for initialization
    void Start()
    {
        behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
    }

    // Update is called once per frame
    void Update()
    {
        ComputeForces();
        HandleVelocity();
    }

    void ComputeForces()
    {
        // reset the force
        force = Vector3.zero;

        //Loop through all behaviours attached to gameobject
        for (int i = 0; i < behaviours.Count; i++)
        {
            SteeringBehaviour behaviour = behaviours[i];
            if (!behaviour.isActive) continue;


            // Calculate the force from it
            force += behaviour.GetForce() * behaviour.weighting;

            //If the force are too big
            if (force.magnitude > maxVelocity)
            {
                //Clamp it to the nax 
                force = force.normalized * maxVelocity;
                //stop calculating
                break;
            }
        }
    }

    void HandleVelocity()
    {
        // Add force to velocity
        velocity += force * Time.deltaTime;
        // Truncate it if we need to
        if(velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }
        // Check if velocity is valid
        if (velocity != Vector3.zero)
        {
            // Add position
            transform.position += velocity * Time.deltaTime;
            // Add rotation
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

}
