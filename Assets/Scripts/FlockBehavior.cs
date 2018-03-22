using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehavior : MonoBehaviour {

    public float speed = 10f;
    public float rotateSpeed = 7f;
    Vector3 avgHead;
    Vector3 avgPos;
    float neighborDist = 12f;

    bool turn = false;

	// Use this for initialization
	void Start () {
        speed = Random.Range(25f, 100f);
	}
	
	// Update is called once per frame
	void Update () {
        //Determines if the flock is turning
        if (Vector3.Distance(transform.position, Vector3.zero) >= FlockPets.areaSize)
        {
            turn = true;
        }
        else
            turn = false;
        //If flock is turning, we calculate direction to center of tank and rotate pets
        if (turn)
        {
            Vector3 dir = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                     Quaternion.LookRotation(dir),
                                                     rotateSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1f);
        }
        else
        {   //If not turning, we apply our rules
            if (Random.Range(0, 5) < 1)
                ApplyTheseRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void ApplyTheseRules()
    {
        GameObject[] gos;
        gos = FlockPets.allPets;

        Vector3 vcent = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.2f;

        Vector3 goalPos = FlockPets.goalPos;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighborDist)
                {
                    vcent += go.transform.position;
                    groupSize++;

                    //Avoids objects if they come too close
                    if(dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    FlockBehavior notherFlock = go.GetComponent<FlockBehavior>();
                    gSpeed = gSpeed + notherFlock.speed;
                }
            }
        }

        //Calculates avg center in the group & calculates avg speed if in a group
        if (groupSize > 0)
        {
            vcent = vcent / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            //Use center vector towards the center and add away from anything we might hit...
            //...then subtract that from current position
            Vector3 dir = (vcent + vavoid) - transform.position;
            //If the direction is zero, we rotate from one direction to another...
            //...without hitting another object
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(dir),
                                                      rotateSpeed * Time.deltaTime);
        }
    }
}
