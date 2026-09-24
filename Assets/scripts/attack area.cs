using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class attackarea : MonoBehaviour
{
    private float angle;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
     if (!Input.GetKeyDown(KeyCode.Space))
     {
        Rigidbody2D body = collider.GetComponent<Rigidbody2D>();
        Transform angle = collider.GetComponent<Transform>();
        
        if (body != null)
    {   
        body.AddTorque(Random.Range(-150f, 150f));
        body.linearVelocity = new Vector2(30f, 10f);
        
    }   
     }
    }   
}       
