using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AranhaMov : MonoBehaviour
{
    public float range;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player; 
    private float TimeBTWShoots;
    public float startTimeBTWShoots;
    public GameObject Tiro;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb=GetComponent<Rigidbody2D>();
        TimeBTWShoots=startTimeBTWShoots; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position)>stoppingDistance)
        {
            transform.position=Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position)<stoppingDistance && Vector2.Distance(transform.position, player.position)>retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position)<retreatDistance)
        {
            transform.position=Vector2.MoveTowards(transform.position, player.position, -speed*Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, player.position) < range)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(TimeBTWShoots<=0)
        {
            Instantiate(Tiro, transform.position, Quaternion.identity);
            TimeBTWShoots=startTimeBTWShoots;
        }
        else
        {
            TimeBTWShoots -= Time.deltaTime;
        }
    }
}
