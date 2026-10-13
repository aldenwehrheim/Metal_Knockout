using NUnit.Framework;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class playerattack : MonoBehaviour
{
   private GameObject attackArea = default;
   private bool attacking = false;
   private float timeToAttack = 0.25f;
   [SerializeField] private Animator animator;
   private float timer = 0f;
   [SerializeField] public PlayerMovement playerMovement;
   float movement;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isWobbling == false)
        {
            attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if(playerMovement.isWobbling == true)
            {
                timer = 0;
            }
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("is1punching",false);
            }
        }
    }
    private void attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("is1punching",true);
    }
}       
