using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length; // armazenar largura do sprite e background
    private float StartPos; // posição inicial

    private Transform cam; //  camera

    public float ParallaxEffect; // valor de cada objeto ~~ velocidade de cada um

    //obs: Variaveis que são declaradas no escopo como private, precisam ser atribuidas a um objeto da unity posteriormente. 
    void Start()
    {
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; // Largura da nossa sprite e background
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() // A real coisa acontece no void Update. Através dele damos valores as variaveis declaradas anteriormente
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect); // Reseta o cenário para dar a sensação de infinito.
        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z); // obs: New vector3 é uma "variavel" que pode armazenar 3 valores. Neste caso, eixo x, y e z

        //Uma hora o cenário tem que parar. Esse conjunto de IF é o responsável por isso.
        if(RePos > StartPos + length)
        {
            StartPos += length;
        }
        else if(RePos < StartPos - length)
        {
            StartPos -= length;
        }

    }
}
