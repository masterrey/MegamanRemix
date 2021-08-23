using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float speed = 10; // velocidade do tiro
    public int damage = 1;
    public float destroyTime = 1.5f;


    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime); // tempo para destruir
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // Movimentação independente dos frames, por isso o time.Deltatime
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
