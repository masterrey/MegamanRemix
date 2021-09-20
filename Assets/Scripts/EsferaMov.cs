using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaMov : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=20;
    public int damage=1;
    Rigidbody2D rb;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
    }
    void OnTriggerEnter2D(Collider2D HitInfo) 
    {
        VidaInimiga enemy = HitInfo.GetComponent<VidaInimiga>();
        if(enemy !=null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
