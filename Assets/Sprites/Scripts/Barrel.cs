using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public int lives;
    public ParticleSystem smoke;
    public ParticleSystem explosion;
    Renderer rend;
    GameObject Respawn;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        Respawn = GameObject.Find("BarrelSpawner");
        if (!GameObject.Find("Test Explosion Prop")) Destroy(gameObject);
        if(rend.enabled==false)rend.enabled = true;
        if(lives<=0)lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 1)
        {
            if (!explosion.IsAlive())
            {
                if (GameObject.Find("Test Explosion Prop"))
                {
                    Instantiate(gameObject, Respawn.transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        lives--;
        if (lives < 3)
        {
            smoke.Play();
        }
        if (lives == 0)
        {
            explosion.Play();
            rend.enabled = false;
        }
    }
}
