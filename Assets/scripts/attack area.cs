using Unity.Collections.Tests.CoreCLR.TestJobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackarea : MonoBehaviour
{

    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health H = collider.GetComponent<Health>();
            H.damage(damage);
        }
    }       
}