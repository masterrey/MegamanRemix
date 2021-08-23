using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicComando : MonoBehaviour
{
    public LayerMask layermascara;
    private Rigidbody2D rb;
    private Animator animator;
    Vector3 diferença;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        diferença = new Vector3(0, 0.15f, 0);
    }
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        if (horz != 0)
        {
            transform.Translate(0.95f * Time.deltaTime * horz, 0, 0);
            animator.SetBool("CORRENDO", true);
            if (horz < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animator.SetBool("CORRENDO", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            animator.SetTrigger("PULAR");
            animator.SetBool("NOCHAO", false);
        }
        else
        {
            animator.SetBool("NOCHAO", true);
        }
    }
    private void FixedUpdate()
    {
        Collider2D[] colisoes = Physics2D.OverlapCircleAll(transform.position - diferença, 0.05f, layermascara);
        if (colisoes.Length == 0)
            animator.SetBool("NOCHAO", false);
        else
            animator.SetBool("NOCHAO", true);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - diferença, 0.05f);
    }
}
