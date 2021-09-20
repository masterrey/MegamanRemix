using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Firepoint;
    public GameObject TiroPrefab;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown("z"))
        {
            Shoot();
        }
    }  
    void Shoot()
    {
        Instantiate(TiroPrefab, Firepoint.position, Firepoint.rotation);
    }
}
