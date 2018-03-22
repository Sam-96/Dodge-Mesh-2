using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockPets : MonoBehaviour {

    public GameObject petPrefab;
    public GameObject petPrefabTwo;
    //public GameObject petPrefabThree;
    public static int areaSize = 1550;

    public static int numPets = 500;
    public static GameObject[] allPets = new GameObject[numPets];

    public static Vector3 goalPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < numPets; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize),
                                      Random.Range(-areaSize, areaSize));
            allPets[i] = Instantiate(petPrefab, pos, Quaternion.identity);
            allPets[i] = Instantiate(petPrefabTwo, pos, Quaternion.identity);
           // allPets[i] = Instantiate(petPrefabThree, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Randomly moves position of goal
        if (Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-areaSize, areaSize),
                                  Random.Range(-areaSize, areaSize),
                                  Random.Range(-areaSize, areaSize));
        }
    }
}
