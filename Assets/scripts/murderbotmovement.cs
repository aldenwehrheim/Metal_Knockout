using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UIElements;

public class murderbotmovement : MonoBehaviour
{
    public Rigidbody2D murderBotbody;
    public float speed;
    public float angle;
    [SerializeField] private Animator animator;
    public bool isWobbling = false;
    private bool reset = false;
    bool isDead = false;
    bool wobbledeadfix = false;
    float difference;
    [SerializeField] public Vector2 respawn_location;
    [SerializeField] public bool respawn = false;
    bool flip = true;
    public Transform playerT;
    public Transform botT;
    public SpriteRenderer spriteRenderer;
    public GameObject object_that_will_Clone;
    private Transform target;
    private Vector2 respawnSpot;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Health H = GetComponent<Health>();
        animator.SetBool("isMdead",false);
        
        respawnSpot = murderBotbody.position;

        if (respawn == true)
        {
            transform.position = respawn_location;
        }
    }

    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        
        Transform position = GetComponent<Transform>();
        Health H = GetComponent<Health>();
        GameObject Target = GameObject.Find("scrappy_0");
        var POS = Target.GetComponent<Transform>();
        Transform Tf = gameObject.transform;
        angle = transform.eulerAngles.z;

        //Debug.Log("bot position is " + position.position.x);
        if (reset == true)
        {
            //Debug.Log("bot velocity is " + murderBotbody.linearVelocity);
            isWobbling = false;
            murderBotbody.linearVelocity = new Vector3(0f, 0f, 0f);
            murderBotbody.angularVelocity = 0f;
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
            animator.SetBool("isMdead",false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            reset = false;
        }

        if(H.health <= 0)
        {
          isDead = true;
          animator.SetBool("isMdead",true);
          //GameObject Nextmurderbot = Instantiate(object_that_will_Clone, new Vector3(0, 1));
        }

        if (POS.TryGetComponent<Transform> (out Transform pos))
        {
            float playerX = pos.position.x;
            float botX = position.position.x;

        if ((playerX > 0 && botX > playerX)||(playerX < 0 && botX > playerX))
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

        if (!isDead && (angle >= 60 && angle <= 80 || angle >= 260 && angle <= 280))
        {
        
         if (!isWobbling)
            
            {
                isWobbling = true;
                float wobbleForce = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity += Vector2.up * wobbleForce;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce2 = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity += Vector2.up * wobbleForce2;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
                
                await Awaitable.WaitForSecondsAsync(1.0f);
                
                float wobbleForce3 = UnityEngine.Random.Range(1f,3f);
                murderBotbody.linearVelocity += Vector2.up * wobbleForce3;
                murderBotbody.AddTorque(UnityEngine.Random.Range(-100f, 100f));
               
                transform.rotation = Quaternion.Euler(0, 0, 0);
                await Awaitable.WaitForSecondsAsync(2.0f); 
                wobbledeadfix = true;

                isWobbling = false;
            }

                
        }
        
        if (reset == true)
        {
            H.health = 4;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isMdead",false);
            reset = false;
        }

        if(H.health <= 0)
        {
          isDead = true;
          animator.SetBool("isMdead",true);
          //GameObject Nextmurderbot = Instantiate(object_that_will_Clone, new Vector3(0, 1));
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
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
        }
    }
    void Reset()
    {
        isDead = false;
        reset = true;
        animator.SetBool("isMdead",false);
    }

}
