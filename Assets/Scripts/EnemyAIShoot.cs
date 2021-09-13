using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShoot : MonoBehaviour
{   
    public Transform player; 
    public float range;
    public GameObject projectile;
    private float timeBtwShots;
    public float startTimeBtwShots;
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots=startTimeBtwShots; 
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < range)
        {
            print("Chegou");
        }
        if(timeBtwShots<=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots=startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
