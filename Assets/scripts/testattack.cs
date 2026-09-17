using System;
using UnityEngine;

public class testattack : MonoBehaviour
{
  private GameObject attackarea = default;
  private bool attacking = false;
  private float timeToattack = 0.25f;
  private float timer = 0f;

    void Start()
    {
        attackarea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
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
    }

    private void Attack()
    {
        attacking = true;
        attackarea.SetActive(attacking);
    }
}
