using System.Data.Common;
using NUnit.Framework;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float speed;
    public float angle;
    public float input;
    private bool isGrounded;
    bool isDead = false;
    [SerializeField] private float slow = 8f;
    private float timer = 0f;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;

    public bool isWobbling = false;

    public SpriteRenderer spriteRenderer;

 
    async void Update()
    {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    
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
            playerBody.linearVelocity = new Vector2 (input * speed, playerBody.linearVelocity.y);
        }

     if (!isDead)
      {
        Health_player H = GetComponent<Health_player>();
        angle = transform.eulerAngles.z;
        if(H.health <= 0)
        {
          isDead = true;  
          animator.SetBool("is_Dead",true);
        }
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
                float wobbleForce = Random.Range(1f,3f);
                playerBody.linearVelocity = Vector2.up * wobbleForce;
                playerBody.AddTorque(Random.Range(-100f, 100f));

                    await Awaitable.WaitForSecondsAsync(.5f);
                animator.SetBool("iswalking",false);
            while (!Input.GetKeyDown(KeyCode.W))
                {
                    await Awaitable.NextFrameAsync();
                }
                animator.SetBool("iswalking",false);
                float wobbleForce2 = Random.Range(1f,3f);
                playerBody.linearVelocity = Vector2.up * wobbleForce2;
                playerBody.AddTorque(Random.Range(-100f, 100f));
                animator.SetBool("is1punching",false);
                    await Awaitable.WaitForSecondsAsync(.5f);
            
            while (!Input.GetKeyDown(KeyCode.W))
                {
                    await Awaitable.NextFrameAsync();
                }
                
                float wobbleForce3 = Random.Range(1f,3f);
                playerBody.linearVelocity = Vector2.up * wobbleForce3;
                playerBody.AddTorque(Random.Range(-100f, 100f));

                    await Awaitable.WaitForSecondsAsync(.5f);

            transform.rotation = Quaternion.Euler(0, 0, 0);

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
     

}        



