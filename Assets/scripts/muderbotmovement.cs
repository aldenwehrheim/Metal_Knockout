using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class muderbotmovement : MonoBehaviour
{
    public Rigidbody2D murderBotbody;
    public float speed;
    public float angle;
    [SerializeField] private Animator animator;
    bool isWobbling = false;
    bool isDead = false;
    bool flip = true;
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
            if(playerX > 0)
            {
                //no flip
                spriteRenderer.flipX = true;
            }
            else
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

                float wobbleForce = Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce;
                murderBotbody.AddTorque(Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce2 = Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce2;
                murderBotbody.AddTorque(Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce3 = Random.Range(1f,3f);
                murderBotbody.linearVelocity = Vector2.up * wobbleForce3;
                murderBotbody.AddTorque(Random.Range(-100f, 100f));
              
                await Awaitable.WaitForSecondsAsync(2.0f); 
                transform.rotation = Quaternion.Euler(0, 0, 0);

                isWobbling = false;
            }

                
        }
        else if (!isWobbling && !isDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (isWobbling == false)
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
