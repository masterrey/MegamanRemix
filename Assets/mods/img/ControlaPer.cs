using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPer : MonoBehaviour
{
    public LayerMask layermascara; // para quais layers eu vou verificar a colisao
    public GameObject bulletPrefab;
    public Transform shotSpawner; // Instanciar os tiros

    private Rigidbody2D rb;
    private Animator animator;
    Vector3 diferenca;
    const float RAIO = 0.15f;

    private float fireRate = 0.5f;
    private float nextFire; // Onde pode atirar dnv

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        diferenca = new Vector3(-0.15f, 0.80f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        if (horz != 0)
        {
            GetComponent<Animator>().SetBool("CORRENDO", true);
            transform.Translate(2f * Time.deltaTime * horz, 0, 0); // faz personagem andar 
            if (horz < 0)
                transform.localScale = new Vector3(-1, 1, 1); // vira a sprite
            else
                transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            GetComponent<Animator>().SetBool("CORRENDO", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 7.5f), ForceMode2D.Impulse); // para valores quebrados colocar "f" do lado
            animator.SetTrigger("PULAR");
            animator.SetBool("NOCHAO", true);
        }
        if (Input.GetButtonDown("Fire1") && Time.time>nextFire) // Intervalo entre os tiros
        {
            nextFire = Time.time + fireRate;
            animator.SetTrigger("Shoot");
            GameObject tempBullet = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);
        }
        

    }


    private void FixedUpdade()
    {
        Collider2D[] colisoes = Physics2D.OverlapCircleAll(transform.position - diferenca, 20f, layermascara);
        if (colisoes.Length == 0)
            animator.SetBool("NOCHAO", false);
        else
            animator.SetBool("NOCHAO", true);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - diferenca, RAIO);
    }
}

