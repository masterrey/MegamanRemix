using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private bool whenDamagedReturnToPoint;
    [SerializeField] private Transform returnPosition;
    private GameObject player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.GetComponent<Control>().Damage();
            if(whenDamagedReturnToPoint==true)
            {
                player.transform.position = returnPosition.transform.position;
            }
        }
    }
}
