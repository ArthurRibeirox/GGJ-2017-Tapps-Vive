using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdGenerator : MonoBehaviour {
    public float density = 1;
    public float variance = 0.1f;
    public GameObject person;
    public GameObject crowdStart;
    public GameObject crowdEnd;
    public float radius = 9;


    // Use this for initialization
    void Start () {
        int b = 0;

        for (float i = crowdStart.transform.position.x; i < crowdEnd.transform.position.x; i += density) {
            for (float j = crowdStart.transform.position.z; j < crowdEnd.transform.position.z; j += density)
            {
                if (i*i + j*j <= radius) continue;
                
                Vector3 position = new Vector3(i + Random.Range(-variance, variance), -0.97f, j + Random.Range(-variance, variance));

                Instantiate(
                    person,
                    position,
                    Quaternion.LookRotation(new Vector3(-position.x, 0, -position.z))
                );
                b += 1;
            }
        }

        print(b);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
