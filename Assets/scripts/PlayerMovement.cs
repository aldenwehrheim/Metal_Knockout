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
    private GameObject attackarea = default;
    private bool attacking = false;
    private float timeToattack = 0.25f;
    private float timer = 0f;

    [SerializeField] private Animator animator;

    bool isWobbling = false;

    public SpriteRenderer spriteRenderer;
    
    void start()
    {
        attackarea = transform.GetChild(0).gameObject;
    }

 async void Update()
    {
        angle = transform.eulerAngles.z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToattack)
            {
                timer = 0;
                attacking = false;
                attackarea.SetActive(attacking);
            }
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

    private void Attack()
    {
        attacking = true;
        attackarea.SetActive(attacking);
    }

    void FixedUpdate()
    {
        playerBody.linearVelocity = new Vector2 (input * speed, playerBody.linearVelocity.y);
     
    }

    
}
