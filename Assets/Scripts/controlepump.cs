using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlepump : MonoBehaviour
{
    Vector3 inicio;
    // Start is called before the first frame update
    void Start()
    {
        inicio = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horz=Input.GetAxis("Horizontal");
        if(horz!=0)
        {
            GetComponent<Animator>().SetBool("CORRENDO",true);
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
            GetComponent<Animator>().SetBool("CORRENDO",false);
        }
        if(Input.GetKey(KeyCode.Z))
        {
            GetComponent<Animator>().SetBool("ATAQUE",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("ATAQUE",false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,3),ForceMode2D.Impulse);   
            GetComponent<Animator>().SetBool("PULO",true);
        }
        else
        {
            GetComponent<Animator>().SetBool("PULO",false);
        }
        //Teste di rati
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag=="TirarVida") 
        {
            gameObject.transform.position = inicio;
            Debug.Log("morreu");
        }
    }
}
