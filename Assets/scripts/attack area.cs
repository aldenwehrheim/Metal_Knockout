using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class attackarea : MonoBehaviour
{
    private float angle;
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<health>() != null)
        {
            health Health = collider.
        

        Rigidbody2D body = collider.GetComponent<Rigidbody2D>();
        Transform angle = collider.GetComponent<Transform>();
        
        if (body != null)
     
        body.AddTorque(Random.Range(-150f, 150f));
        body.linearVelocity = new Vector2(30f, 10f);
        }
    }
}       
