using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEs : MonoBehaviour
{
    // Start is called before the first frame update
    public int Vidas=1;
    
    private void OnCollisionEnter2D(Collision2D collision) //Morte
    {
        if(collision.gameObject.tag=="TirarVida") 
        {
            Vidas--;//vidas-1= ou vidas=vidas-1;
            if(Vidas==0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
