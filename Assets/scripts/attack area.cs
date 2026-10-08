using Unity.Collections.Tests.CoreCLR.TestJobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using JetBrains.Annotations;


public class attackarea : MonoBehaviour
{
    public int damage = 1;
    public float angle;
    private void Update()
    {
        GameObject target = GameObject.Find("scrappy_0");
        var SR = target.GetComponent<SpriteRenderer>();
        PolygonCollider2D PC = GetComponent<PolygonCollider2D>();
        Transform Tf = gameObject.transform;
        
     if (SR == null)
        {
            Debug.Log("null");
        }
     if (SR.flipX == false || true)
        {
            Debug.Log("connected?");
        }
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