using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdGenerator : MonoBehaviour {
    public float density = 1;
    public GameObject person;
    public GameObject crowdStart;
    public GameObject crowdEnd;


    // Use this for initialization
    void Start () {
        int b = 0;

        for (float i = crowdStart.transform.position.x; i < crowdEnd.transform.position.x; i += density)
            for (float j = crowdStart.transform.position.z; j < crowdEnd.transform.position.z; j += density)
            {
                Instantiate(person, new Vector3(i, 0.67f, j), Quaternion.identity);
                b += 1;
            }

        print(b);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
