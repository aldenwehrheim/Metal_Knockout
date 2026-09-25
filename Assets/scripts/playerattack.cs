using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class playerattack : MonoBehaviour
{
   private GameObject attackarea = default;
   private bool attacking = false;
   private float timeToAttack = 0.25f;
   private float timer = 0f;

    void Start()
    {
        attackarea = transform.GetChild(0).gameObject;
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
                attackarea.SetActive(attacking);
            }
        }
    }
    private void attack()
    {
        attacking = true;
        attackarea.SetActive(attacking);
    }
}       
