using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour
{
    [SerializeField]
    Vector3 raio=new Vector3(10,0,0);
    [SerializeField]
    float velocity=0.5f;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    LayerMask layerMaskAndar;
    float largura;
    float altura;
    float sentido=1;
    // Start is called before the first frame update
    void Start()
    {
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
        altura = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void OnDrawGizmos() 
    {
        Gizmos.DrawCube(transform.position+new Vector3(largura,0,0), new Vector3(largura,altura,1));    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i=0; i<2; i++)
        {
            Debug.DrawLine(transform.position, transform.position+raio*sentido, Color.red);
            //RaycastHit2D obj = Physics2D.Linecast(transform.position, transform.position+raio*sentido,layerMask);
            Vector3 posInimigo=transform.position+new Vector3(largura*sentido,0,0);
            RaycastHit2D obj = Physics2D.Linecast(posInimigo, posInimigo+raio*sentido);
            if(obj.collider!=null && obj.collider.tag=="Player")
            {
                Vector3 posicao=transform.position + new Vector3(largura*sentido,0,0);
                Vector2 SentidoBox=new Vector2(sentido, 0);
                Vector3 TamanhoBox=new Vector3(largura, altura,0);
                RaycastHit2D[] cols=Physics2D.BoxCastAll(posicao,TamanhoBox,0,SentidoBox, 0, layerMaskAndar);
                if(cols.Length>0)
                {
                    transform.Translate(raio.normalized*velocity*sentido*Time.deltaTime);
                    transform.localScale=new Vector3(1*sentido,1,1);
                }
                
                break;
            }
            sentido = -sentido;
        }
    }
}
