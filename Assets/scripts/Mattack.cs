using System.Threading;
using NUnit.Framework;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class Mattack : MonoBehaviour
{
   private GameObject attackArea = default;
   private bool attacking = false;
   private float timeToAttack = 0.25f;
   [SerializeField] Animator animator;
   private float timer = 0f;
   public murderbotmovement murderbotMovement;
   float movement;
   [SerializeField] float cooldown;
   public Transform playerT;
   public Transform botT;
    

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

    void Update()
    {
        float difference = Vector3.Distance(playerT.position, botT.position);
    
        if (cooldown == 0 && (difference <= 1.5 && murderbotMovement.isWobbling == false))
        {
            attack();
            cooldown = 1000;
        }
        if (attacking)
        {
            Debug.Log(cooldown + "cooldown left");
            timer += Time.deltaTime;
            if(murderbotMovement.isWobbling == true)
            {
                timer = 0;
                animator.SetBool("Mattacttacking", true);
            }
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("isMattattacking",false);
            }
        }
    
    if (cooldown != 0)
        {
         cooldown -= 1;
         if(cooldown <= 0)
            {
                cooldown = 0;
            }   
        }
    }
    private void attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("isMattattacking",true);
    }
}       
