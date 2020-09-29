using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    private HashSet<Rigidbody2D> affectedBodies = new HashSet<Rigidbody2D>();
    private Rigidbody2D componentRigidbody;
    public float strength = 29.0f;
    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody != null && other.name != "Mass")
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D body in affectedBodies)
        {
            Vector2 forceDirection = (new Vector2(transform.position.x,  transform.position.y) - body.position).normalized;
            body.AddForce(forceDirection * strength);
        }
    }
}