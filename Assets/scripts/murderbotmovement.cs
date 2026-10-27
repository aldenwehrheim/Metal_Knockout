using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class murderbotmovement : MonoBehaviour
{
    public Rigidbody2D murderBotbody;
    public float speed;
    public float angle;
    [SerializeField] private Animator animator;
    public bool isWobbling = false;
    bool isDead = false;
    bool wobbledeadfix = false;
    float difference;
    bool flip = true;
    public Transform playerT;
    public Transform botT;
    
    public SpriteRenderer spriteRenderer;
    

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Health H = GetComponent<Health>();
        animator.SetBool("isMdead",false);
    }

    async void Update()
    {
        Transform M_pos = GetComponent<Transform>();
        //Debug.Log("M_pos is " +M_pos.position.x);
        GameObject Target = GameObject.Find("scrappy_0");
        var POS = Target.GetComponent<Transform>();
        Health H = GetComponent<Health>();
        Transform Tf = gameObject.transform;
        if(H.health <= 0)
        {
          isDead = true;  
        }
        if (POS.TryGetComponent<Transform> (out Transform pos))
        {
            float playerX = pos.position.x;
            float botX = M_pos.position.x;
            if((playerX > 0 && botX > playerX)||(playerX < 0 && botX > playerX))
            {
                //no flip
                spriteRenderer.flipX = true;
            }
            else if ((playerX < 0 && botX < playerX)||(playerX > 0 && botX < playerX))
            {
                // yes flip
                spriteRenderer.flipX = false;
            }
        }
        angle = transform.eulerAngles.z;

        if (!isDead && (angle >= 60 && angle <= 80 || angle >= 260 && angle <= 280))
        {
        
         if (!isWobbling)
            
            {
                isWobbling = true;
                float wobbleForce = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce2 = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce2;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce3 = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce3;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
              
<<<<<<< HEAD:Assets/scripts/muderbotmovement.cs
                await Awaitable.WaitForSeconds(2.0f); 
                transform.rotation = Quaternion.Euler(0, 0, 0);
=======
                await Awaitable.WaitForSecondsAsync(2.0f); 
                wobbledeadfix = true;
>>>>>>> 7bd4e8fc0e707bfa290e75b651b72f2794e88cc1:Assets/scripts/murderbotmovement.cs

                isWobbling = false;
            }

                
        }
        if(H.health <= 0)
        {
          isDead = true;  
        }
        if (wobbledeadfix == true && isDead == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            wobbledeadfix = false;
        }
        //float Abvalue = Math.Abs(target.position.x) - Math.Abs(transform.position.x);
        float difference = Vector3.Distance(playerT.position, botT.position);
        if (!isWobbling && !isDead && (difference > 1.5))
        {
<<<<<<< HEAD:Assets/scripts/muderbotmovement.cs
            transform.position.x = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
=======
            Debug.Log("walk");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
>>>>>>> 7bd4e8fc0e707bfa290e75b651b72f2794e88cc1:Assets/scripts/murderbotmovement.cs
        }
Async
        if (isWobbling == false && (difference > 1.8))
        {
            animator.SetBool("isMwalking",true);
            
        }
        else
        {
            animator.SetBool("isMwalking",false);
        }
        if (isDead == true)
        {
            animator.SetBool("isMwalking",false);
            animator.SetBool("isMdead",true);
        }
    }

}
