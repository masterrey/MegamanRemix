using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
    [SerializeField]
    GameObject target;
    Rigidbody2D rdb;
    [SerializeField]
    float advanceFactor = 2;
	
	
	void LateUpdate () {
        if (target)
        {
            if (rdb)
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(target.transform.position.x +
                    rdb.velocity.x * advanceFactor
                    , target.transform.position.y
                    , transform.position.z), Time.smoothDeltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position,
                   new Vector3(target.transform.position.x
                   , target.transform.position.y
                   , transform.position.z), Time.smoothDeltaTime);

            }
        }
	}
    /// <summary>
    /// Seta o jogador na camera
    /// </summary>
    /// <param name="tgt">jogador</param>
    public void SetPlayer(GameObject tgt)
    {
        target = tgt;
        rdb = target.GetComponent<Rigidbody2D>();
    }
}
