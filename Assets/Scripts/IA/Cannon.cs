using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject missileReference;
    [SerializeField]
    private GameObject firepoint;

    [SerializeField]
    private GameObject cannon;

    [SerializeField]
    int state = 0;

    Rigidbody2D rb;

    float cooldown = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (state)
        {
            case 0:
                Idle();
                break;
            case 1:
                Aim();
            break;
            case 2:
                Follow();
            break;
        }   
    }

    void Idle()
    {

    }

    void Aim()
    {
        Vector3 dif = target.transform.position+Vector3.up - transform.position;
        //cannon.transform.up = -dif;
        float value = Vector3.Dot(dif, cannon.transform.right);
        cannon.transform.Rotate(0, 0, value);
        if (cooldown <= 0)
        {
            Instantiate(missileReference, firepoint.transform.position, firepoint.transform.rotation) ;
            cooldown = 1;
        }
        cooldown -= Time.deltaTime;
    }
    void Follow()
    {
        if (!target) return;
        if (target.transform.position.x > transform.position.x)
        {
            rb.AddForce(Vector2.right * 100);
        }
        if (target.transform.position.x < transform.position.x)
        {
            rb.AddForce(Vector2.right * -100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject;
            state = 1; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = 2;
        }
    }
}
