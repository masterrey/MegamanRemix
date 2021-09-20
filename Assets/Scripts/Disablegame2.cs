using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disablegame2 : MonoBehaviour
{
    public GameObject square2;

    void Start()
    {
        if (square2.activeInHierarchy == true)
        {
            square2.SetActive(false);
        }
    }

    void Update()
    {
        if (NinjaComando.active2 == true)
        {
            if (square2.activeInHierarchy == false)
                square2.SetActive(true);

        }
        else if (NinjaComando.active2 == false)
        {
            if (square2.activeInHierarchy == true)
            {
                square2.SetActive(false);

            }

        }

    }
}
