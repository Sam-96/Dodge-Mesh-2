/*using System.Collections;
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

*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FollowTarget : MonoBehaviour
{

    public int speed;
    public GameObject player;

    void Update()
    {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        //transform.LookAt(player);
    }
}
