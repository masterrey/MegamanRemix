using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float Speed;
    public float Range;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float DistanceFromPlayer=Vector2.Distance(player.position, transform.position);
        if(DistanceFromPlayer<Range)
        {
            transform.position=Vector2.MoveTowards(this.transform.position, player.position, Speed*Time.deltaTime);
        }
        if(player.position.x<=transform.position.x)
        {
            transform.localScale=new Vector3(1,1,1);
        }
        if(player.position.x>=transform.position.x)
        {
            transform.localScale=new Vector3(-1,1,1);
        }
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
