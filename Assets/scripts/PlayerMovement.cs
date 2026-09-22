using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float speed;
    public float angle;
    public float input;
  
    private float timer = 0f;

    [SerializeField] private Animator animator;

    bool isWobbling = false;

    public SpriteRenderer spriteRenderer;
    

 async void Update()
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
        
        if (!isWobbling && (angle >= 80 && angle <= 100 || angle >= 260 && angle <= 280))
        {
            isWobbling = true;
            animator.SetBool("iswalking",false);
            input = 0;

            while (!Input.GetKeyDown(KeyCode.W))
            {
                await Awaitable.NextFrameAsync();
            }
                
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


    void FixedUpdate()
    {
        playerBody.linearVelocity = new Vector2 (input * speed, playerBody.linearVelocity.y);
     
    }

    
}
