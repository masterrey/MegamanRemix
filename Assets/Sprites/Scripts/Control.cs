using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Animator anima;
    float xmov;
    public Rigidbody2D rdb;
    bool jump, doublejump;
    float jumptime, jumptimeside;
    public ParticleSystem fire;
    float LastPosition, DeltaPosition;
    [Range(0, 20)] public float MoveSpeed = 20;
    [Range(1f, 1.2f)] public float JumpForce = 1;
    private float LastTime;
    public float ShootCooldown;
    [Range(0, 5)] public int vida;
    private float timer;
    public GameObject playerprefab;
    private GameObject respawn;
    void Start()
    {
        respawn = GameObject.Find("Respawn");
    }
    void Update()
    {
        if (vida<=0)
        {
            vida = 5;
            Instantiate(playerprefab, respawn.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        xmov = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            if (jumptime < 0.1f)
            {
                doublejump = true;
            }
        }

        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
        else
        {
            jump = false;
            doublejump = false;
            jumptime = 0;
            jumptimeside = 0;
        }
        anima.SetBool("Fire", false);
        LastTime += Time.fixedDeltaTime;
        if (Input.GetButtonDown("Fire1") && LastTime>ShootCooldown)
        {
            fire.Emit(1);
            anima.SetBool("Fire", true);
            LastTime = 0;
        }

    }

    void FixedUpdate()
    {
        Reverser();
        anima.SetFloat("Velocity", Mathf.Abs(xmov));
        //rdb.velocity = new Vector2(xmov * 1.3f, rdb.velocity.y);

        rdb.AddForce(new Vector2(xmov * MoveSpeed / (rdb.velocity.magnitude + 1), 0));

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit)
        {
            anima.SetFloat("Height", hit.distance);
            JumpRoutine(hit);
        }

        RaycastHit2D hitright;
        hitright = Physics2D.Raycast(transform.position +
            Vector3.up * 0.5f, transform.right, 1);

        if (hitright)
        {
            if (hitright.distance < 0.3f)
            {
                JumpRoutineSide(hitright);
            }
            Debug.DrawLine(hitright.point, transform.position
                + Vector3.up * 0.5f);
        }
        if (anima.GetCurrentAnimatorStateInfo(0).IsName("JumpFly"))
        {
            //if(anima.GetFloat("Height")-LastPosition<0)
            if (((anima.GetFloat("Height") - LastPosition) / Time.fixedDeltaTime) < 0)
            {
                if (((anima.GetFloat("Height") - LastPosition) / Time.fixedDeltaTime) * 20 > -90)
                {
                    transform.Rotate(0, 0, (((anima.GetFloat("Height") - LastPosition) / Time.fixedDeltaTime) * 20) - transform.eulerAngles.z, Space.Self);
                }
            }
            // transform.Rotate(0,0, (DeltaPosition/Time.fixedDeltaTime), Space.Self);
            LastPosition = anima.GetFloat("Height");
            //transform.Rotate(0, 0, 0, Space.Self);
        }
        else
        {
            transform.Rotate(-transform.eulerAngles.x, 0, -transform.eulerAngles.z, Space.Self);
        }

    }
    /// <summary>
    /// rotina de pulo parte fisica
    /// </summary>
    /// <param name="hit">coloque aqui o raycast hit para altura do chao</param>
    private void JumpRoutine(RaycastHit2D hit)
    {
        if (hit.distance < 0.1f *(transform.localScale.x))
        {
            if (hit.transform.gameObject.tag == ("Ground") || hit.transform.gameObject.tag == ("MovableObjects"))
            {
                jumptime = 1;
            }
        }


        if (jump)
        {
            jumptime = Mathf.Lerp(jumptime*JumpForce, 0, Time.fixedDeltaTime * 10);
            rdb.AddForce(Vector2.up * jumptime, ForceMode2D.Impulse);
        }

    }

    private void JumpRoutineSide(RaycastHit2D hitside)
    {
        if (hitside.distance < 0.3f*(transform.localScale.x))
        {
            if (hitside.transform.gameObject.tag == ("Ground") || hitside.transform.gameObject.tag == ("MovableObjects"))
            {
                jumptimeside = 1;
            }
        }

        if (doublejump)
        {
            PhisicalReverser();
            jumptimeside = Mathf.Lerp(jumptimeside, 0, Time.fixedDeltaTime * 10);
            rdb.AddForce((hitside.normal * 50 + Vector2.up * 80) * jumptimeside);
        }
    }




    /// <summary>
    /// funcao pra inverter o personagem
    /// </summary>
    void Reverser()
    {
        if (xmov > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (xmov < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
    void PhisicalReverser()
    {
        if (rdb.velocity.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (rdb.velocity.x < 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damage"))
        {
            LevelManager.instance.LowDamage();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Explosion")) Damage();
    }
    public void Damage()
    {
        if((Time.time - timer) > 2)
        {
            timer = Time.time;
            vida--;
        }
    }
}
