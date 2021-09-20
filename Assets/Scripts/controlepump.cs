using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlepump : MonoBehaviour
{   
    [SerializeField]
    Text MarcadorVidas;
    [SerializeField]//modificar variaveis privadas
    int Vidas=3;
    Vector3 inicio;
    public LayerMask LayerMascara; 
    private Rigidbody2D rb;
    private Animator Animator;
    int pulos;
    const int PULOS = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
        inicio = gameObject.transform.position;
        pulos = PULOS;
        AtualizarMarcadorVidas();
    }

    // Update is called once per frame
    void Update()
    {
        float horz=Input.GetAxis("Horizontal");
        if(horz!=0)
        {
            Animator.SetBool("CORRENDO",true);
            transform.Translate(1*Time.deltaTime*horz,0 ,0);
            if(horz<0)
            {
                transform.localScale=new Vector3(-1,1,1);
            }
            else
            {
                transform.localScale=new Vector3(1,1,1);
            }
        }
        else
        {
            Animator.SetBool("CORRENDO",false);
        }
        if(Input.GetKey(KeyCode.Z))
        {
            Animator.SetBool("ATAQUE",true);
        }
        else
        {
            Animator.SetBool("ATAQUE",false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && (Animator.GetBool("NOCHAO") || pulos>1))
        {
            //GetComponent<Rigidbody2D>().velocity=new Vector2 (0,3f);
            rb.AddForce(new Vector2 (0, 3f),ForceMode2D.Impulse);   
            Animator.SetTrigger("PULO");
            Animator.SetBool("NOCHAO",false);
            pulos -= 1;
        }
        //Teste di rati
    }
    private void FixedUpdate() //Ver se esta no chão
    {
        if(Animator.GetBool("NOCHAO")==false)
        {
            Collider2D[] colisoes=Physics2D.OverlapCircleAll(transform.position - new Vector3(0,0.1f,0), 0.1f, LayerMascara);
            if(colisoes.Length==0)
            {
                Animator.SetBool("NOCHAO", false);
            }
            else
            {
                Animator.SetBool("NOCHAO", true);
                pulos= PULOS;
            }
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision) //Morte
    {
        if(collision.gameObject.tag=="TirarVida") 
        {
            gameObject.transform.position = inicio;//volta pra tela inicial
            Vidas--;//vidas-1= ou vidas=vidas-1;
            AtualizarMarcadorVidas();
            if(Vidas==0)
            {
                Morreu();
                Debug.Log("morreu");
            }
        }
        if(collision.gameObject.tag=="Next")
        {
            SceneManager.LoadScene("Boss1");
        }
    }
    private void AtualizarMarcadorVidas()
    {
        MarcadorVidas.text = "Vidas: "+Vidas.ToString("00");
    }
    private void Morreu()
    {
        SceneManager.LoadScene("GameOver");
    }
}
