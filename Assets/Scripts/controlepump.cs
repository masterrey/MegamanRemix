using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlepump : MonoBehaviour
{
    Vector3 inicio;
    public LayerMask LayerMascara; 
    private Rigidbody2D rb;
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
        inicio = gameObject.transform.position;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody2D>().velocity=new Vector2 (0,3f);
            rb.AddForce(new Vector2 (0, 3f),ForceMode2D.Impulse);   
            Animator.SetBool("PULO",true);
            Animator.SetBool("NOCHAO",false);
        }
        else
        {
            Animator.SetBool("PULO",false);
        }
        //Teste di rati
    }

    private void FixedUpdate() 
    {
        if(Animator.GetBool("NOCHAO")==false)
        {
            Collider2D[] colisoes=Physics2D.OverlapCircleAll(transform.position - new Vector3(0,0.1f,0), 0.1f, LayerMascara);
            if(colisoes.Length==0)
            {
                Animator.SetBool("NOCHAO", true);
            }
            else
            {
                Animator.SetBool("NOCHAO", false);
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //GetComponent<Animator>().SetBool("NOCHAO", true);
        if(collision.gameObject.tag=="TirarVida") 
        {
            gameObject.transform.position = inicio;
            Debug.Log("morreu");
        }
    }
}
