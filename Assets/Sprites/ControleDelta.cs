using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDelta : MonoBehaviour
{
    Animator anim;// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Movendo", true);

        }
        else
        {
            anim.SetBool("Movendo", false);
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Pulando", true);
        }
        else
        {
            anim.SetBool("Pulando", false);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool("Atirando", true);
        }
        else
        {
            anim.SetBool("Atirando", false);

        }
    }
}
