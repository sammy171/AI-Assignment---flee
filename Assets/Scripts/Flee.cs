using UnityEngine;
using System.Collections;

public class Flee : SteeringBehaviour
{
    public Transform target;

    public override Vector3 GetForce()
    {
        // Create a new force
        Vector3 force = Vector3.zero;

        //if there is no target
        if (target == null) return force;

        Vector3 desiredForce;

        // Get the direction from target to agent
        Vector3 direction = target.position + transform.position;

        // Check if the direction is valid
        if (direction != Vector3.zero)
        {
            // Calculate force
            desiredForce = direction.normalized * weighting;
            force = desiredForce - owner.velocity;
        }

        // Return the force
        return force;
    }


}
