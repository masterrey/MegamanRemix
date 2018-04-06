using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
    public GameObject target;
    Rigidbody2D rdb;
	// Use this for initialization
	void Start () {
        rdb = target.GetComponent<Rigidbody2D>();

    }
	
	void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.transform.position.x +
            rdb.velocity.x * 3
            , target.transform.position.y
            , transform.position.z), Time.smoothDeltaTime);
	}
}
