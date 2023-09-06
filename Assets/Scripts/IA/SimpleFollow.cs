using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    public GameObject target;
    Rigidbody2D rdb;


    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called each 0.04 of second
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 dif = target.transform.position - transform.position;
            rdb.AddForce(dif);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            target = collision.gameObject;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            target = null;
        }
    }
}
