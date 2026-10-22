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
   public Transform playerT;
   public Transform botT;
    

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

    void Update()
    {
        float difference = Vector3.Distance(playerT.position, botT.position);
        if (((difference <= 1.5) || Input.GetKeyDown(KeyCode.F)) && murderbotMovement.isWobbling == false)
        {
            attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if(murderbotMovement.isWobbling == true)
            {
                timer = 0;
            }
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("isMattattacking",false);
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
