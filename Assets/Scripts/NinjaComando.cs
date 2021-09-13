using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinjaComando : MonoBehaviour
{
    [SerializeField]
    Text MarcadorVidas;
    [SerializeField]
    int vidas = 3;
    public LayerMask layermascara;
    private Rigidbody2D rb;
    private Animator animator;
    Vector3 diferença;
    Vector3 inicio;
    int pulos;
    const int PULOS = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        diferença = new Vector3(0, 0.15f, 0);
    }

    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.Space) && (animator.GetBool("NOCHAO") || pulos > 1))
        {
            rb.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            animator.SetTrigger("PULAR");
            animator.SetBool("NOCHAO", false);
            pulos -= 1;
        }


    }

    private void FixedUpdate()
    {
        Collider2D[] colisoes = Physics2D.OverlapCircleAll(transform.position - diferença, 0.07f, layermascara);
        if (colisoes.Length == 0)
        {
            animator.SetBool("NOCHAO", false);
        }
        else
        {
            animator.SetBool("NOCHAO", true);
            pulos = PULOS;
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - diferença, 0.05f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TiraVida")
        {
            transform.position = inicio;
            vidas--;
            MarcadorVidas.text = "Vidas: " + vidas.ToString("00");
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            vidas--;
            transform.position = inicio;
            MarcadorVidas.text = "Vidas: " + vidas.ToString("00");
        }
        if (vidas == 0)
        {
            Morreu();
        }
    }
    private void Morreu()
    {
        SceneManager.LoadScene("GameOver");

    }
}
