using System;
using System.Data.Common;
using System.Numerics;
using NUnit.Framework;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float speed;
    public float angle;
    public float input;
     private bool reset = false;
    private bool isGrounded;
    bool isDead = false;
    [SerializeField] private float slow = 8f;
    private float timer = 0f;

    [SerializeField] public UnityEngine.Vector2 respawn_location;
    [SerializeField] public bool respawn = false;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    private UnityEngine.Vector2 respawnSpot;
    public bool isWobbling = false;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        Health_player H = GetComponent<Health_player>();
        animator.SetBool("is_Dead",false);
        
        respawnSpot = playerBody.position;

        if (respawn == true)
        {
            transform.position = respawn_location;
        }
    }

    async void Update()
    {
    Health_player H = GetComponent<Health_player>();    
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    Transform position = GetComponent<Transform>();

    if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

    if (reset == true)
        {
            animator.SetBool("is_Dead",false);
            isWobbling = false;
            playerBody.linearVelocity = new UnityEngine.Vector3(0f, 0f, 0f);
            playerBody.angularVelocity = 0f;
            //transform.position = new Vector2(7.6f , 1.5f);
            if (respawn == false)
            {
                transform.position = respawnSpot;
            }
            else if (respawn == true)
            {
                transform.position = respawn_location;
            }
            H.health = 4;
            animator.SetBool("is_Dead",false);
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
            animator.SetBool("is_Dead",false);
            reset = false;
        }

    if(H.health <= 0)
        {
          isDead = true;
          animator.SetBool("is_Dead",true);
          //GameObject Nextmurderbot = Instantiate(object_that_will_Clone, new Vector3(0, 1));
        }
        
    if (isGrounded == true)
        {
            rb.linearDamping = slow;
            Debug.Log ("grounded");
        }
    if (isGrounded == false)
        {
            rb.linearDamping = 0f;
            Debug.Log ("notgrounded");
        }
    if (input != 0 )
        {
            playerBody.linearVelocity = new UnityEngine.Vector2 (input * speed, playerBody.linearVelocity.y);
        }

     if (!isDead)
      {
        angle = transform.eulerAngles.z;

        if (!isWobbling)
        {
            input = Input.GetAxisRaw("Horizontal");

            if (input < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (input > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
            angle = transform.eulerAngles.z;
        
        if (!isDead && !isWobbling && (angle >= 80 && angle <= 100 || angle >= 260 && angle <= 280))
        {
            isWobbling = true;
            animator.SetBool("iswalking",false);
            input = 0;
            animator.SetBool("is1punching",false);
            
            while (!Input.GetKeyDown(KeyCode.W))
            {
                await Awaitable.NextFrameAsync();
            }
                animator.SetBool("is1punching",false);
                float wobbleForce = UnityEngine.Random.Range(1f,3f);
                playerBody.linearVelocity = UnityEngine.Vector2.up * wobbleForce;
                playerBody.AddTorque(UnityEngine.Random.Range(-100f, 100f));

                    await Awaitable.WaitForSecondsAsync(.5f);
                animator.SetBool("iswalking",false);
            while (!Input.GetKeyDown(KeyCode.W))
                {
                    await Awaitable.NextFrameAsync();
                }
                animator.SetBool("iswalking",false);
                float wobbleForce2 = UnityEngine.Random.Range(1f,3f);
                playerBody.linearVelocity = UnityEngine.Vector2.up * wobbleForce2;
                playerBody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
                animator.SetBool("is1punching",false);
                    await Awaitable.WaitForSecondsAsync(.5f);
            
            while (!Input.GetKeyDown(KeyCode.W))
                {
                    await Awaitable.NextFrameAsync();
                }
                
                float wobbleForce3 = UnityEngine.Random.Range(1f,3f);
                playerBody.linearVelocity = UnityEngine.Vector2.up * wobbleForce3;
                playerBody.AddTorque(UnityEngine.Random.Range(-100f, 100f));

                    await Awaitable.WaitForSecondsAsync(.5f);

            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);

            isWobbling = false;
        }

           if (input != 0 && isWobbling == false)
        {
            animator.SetBool("iswalking",true);
            
        }
        else
        {
            animator.SetBool("iswalking",false);
        }
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
        isGrounded = false;
        }
    }
    void Reset()
    {
        isDead = false;
        reset = true;
        animator.SetBool("is_Dead",false);
    }
     

}        


