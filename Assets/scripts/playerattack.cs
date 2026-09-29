using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class playerattack : MonoBehaviour
{
   private GameObject attackArea = default;
   private bool attacking = false;
   private float timeToAttack = 0.25f;
   private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
    private void attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}       
