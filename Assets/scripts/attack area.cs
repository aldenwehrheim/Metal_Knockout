using Unity.Collections.Tests.CoreCLR.TestJobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class attackarea : MonoBehaviour
{
    public int damage = 1;
    public GameObject scrappy_0;
    public float angle;
    private SpriteRenderer SR;
    private void Update()
    {
        
        PolygonCollider2D PC = GetComponent<PolygonCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        Transform Tf = gameObject.transform;

     if(SR.flipX == true)
        {
         PC.offset = new Vector2(4f,0f);   
         Tf.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
          PC.offset = new Vector2(0f,0f);   
          Tf.rotation = Quaternion.Euler(0,0,0);  
        }
    }
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