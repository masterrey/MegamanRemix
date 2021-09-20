using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disablegame : MonoBehaviour
{
    public GameObject square;

    void Start()
    {
        if (square.activeInHierarchy == true)
        {
            square.SetActive(false);
        }
    }
      
    void Update()
    {
        if (NinjaComando.active == true)
        {
            if (square.activeInHierarchy == false)
                square.SetActive(true);
        
        }
        else if(NinjaComando.active == false)
        {
            if(square.activeInHierarchy == true)
            {
                square.SetActive(false);

            }

        }
         
    }
    
}
