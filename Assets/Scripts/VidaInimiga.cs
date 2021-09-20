using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimiga : MonoBehaviour
{
    // Start is called before the first frame update
    public int health=3;
    
    public void TakeDamage(int damage)
    {
        health -=damage;
        if(health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
