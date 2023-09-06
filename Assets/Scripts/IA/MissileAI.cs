using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAI : MonoBehaviour
{

    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);

        GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject,0.6f);
            explosion.Play();
        }
    }
}
