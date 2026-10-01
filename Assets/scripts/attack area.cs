using Unity.Collections.Tests.CoreCLR.TestJobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackarea : MonoBehaviour
{
    public int damage = 1;
    public float angle;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health H = collider.GetComponent<Health>();
            H.Damage(damage);
            
            Rigidbody2D body = collider.GetComponent<Rigidbody2D>();
            Transform angle = collider.GetComponent<Transform>();

                if (body != null)
                 {   
                    body.AddTorque(Random.Range(-100f, 100f));
                    body.linearVelocity = new Vector2(10f, 5f);
                 }   
        }
    }       
}