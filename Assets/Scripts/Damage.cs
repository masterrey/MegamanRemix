using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int lives=4;

    int initiallives;
    [SerializeField]
    ParticleSystem smoke;
    [SerializeField]
    ParticleSystem explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        initiallives = lives;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {

        StartCoroutine(Blink());

        lives--;
        if (lives < initiallives/2)
        {
            CreateandPlay(smoke);
        }

        if (lives < 1)
        {
            CreateandPlay(explosion);

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (!renderer)
            {
                renderer = GetComponentInChildren<SpriteRenderer>();
            }
            renderer.enabled = false;
            Destroy(gameObject, 0.8f);
        }

        
      
    }
    /// <summary>
    /// cria uma particula e liga ela
    /// </summary>
    /// <param name="particle"> colocar aqui a referencia da particula (prefab)</param>
    void CreateandPlay(ParticleSystem particle)
    {
        if (particle)
        {
            GameObject ob = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
            ob.transform.parent = gameObject.transform;
            ob.GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator Blink()
    {

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (!renderer)
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
        }
        for (int i = 0; i < 5; i++)
        {
            renderer.color = new Color(1, 0, 0);

            yield return new WaitForSeconds(0.1f);

            renderer.color = new Color(1, 1, 1);

            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
