using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactite : MonoBehaviour
{
    [SerializeField] private GameObject fallingPrefab;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(fallingPrefab, gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
