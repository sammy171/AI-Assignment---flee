using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AIAgent))]
public class SteeringBehaviour : MonoBehaviour
{
    public float weighting = 7.5f;
    public Vector3 force;
    [HideInInspector] public AIAgent owner; //dont want to show in Inspector, but still available to access
    [HideInInspector] public bool isActive; //dont want to show in Inspector, but still available to access

    void Awake()
    {
        owner = GetComponent<AIAgent>();
    }
    public virtual Vector3 GetForce()
    {
        return Vector3.zero;
    }

    void OnEnable() { isActive = true; }

    void OnDisable() { isActive = false; }
}
