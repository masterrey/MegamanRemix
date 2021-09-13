using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIGround : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public Transform enemyGFX;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    
    void FixedUpdate() 
    {
        if(TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    void UpdatePath() 
    {
        if(followEnabled && TargetInDistance() && seeker.IsDone())  
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }  
    }

    void PathFollow()
    {
        if(path==null)
        {
            return;
        }
        if(currentWaypoint>=path.vectorPath.Count)
        {
            return;
        }

        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);

        //calculo de direção
        Vector2 direction= ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction*speed*Time.deltaTime;

        //Pulo
        if (jumpEnabled && isGrounded)
        {
            if(direction.y>jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up*speed*jumpModifier);
            }
        }

        //Movimento
        rb.AddForce(force);

        //next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance<nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Direção do sprite
        if(directionLookEnabled)
        {
            if(force.x>=0.01f)
            {
                enemyGFX.localScale = new Vector3(1f,1f,1f);
            }
            else if(force.x<=0.01f)
            {
                enemyGFX.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position)<activateDistance;
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint=0;
        }
    }
}
