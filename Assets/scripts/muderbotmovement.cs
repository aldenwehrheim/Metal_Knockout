using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class muderbotmovement : MonoBehaviour
{
    public Rigidbody2D murderBotbody;
    public float speed;
    public float angle;
    [SerializeField] private Animator animator;
    bool isWobbling = false;
    

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    async void Update()
    {
        
        angle = transform.eulerAngles.z;

        if (angle >= 60 && angle <= 80 || angle >= 260 && angle <= 280)
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
        else if (!isWobbling)
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
        
    }
}
