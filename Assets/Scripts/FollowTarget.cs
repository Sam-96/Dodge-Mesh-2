using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;

    float speed = 10f;
    Vector3 lookDir;

    const float EPSILON = 0.1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lookDir = (target.position - transform.position).normalized;

        if ((transform.position - target.position).magnitude > EPSILON)
            transform.Translate(lookDir * Time.deltaTime * speed);
	}
}
