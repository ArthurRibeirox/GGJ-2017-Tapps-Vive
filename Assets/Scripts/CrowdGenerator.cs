using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdGenerator : MonoBehaviour {
    public float density = 1;
    public float variance = 0.1f;
    public GameObject person;
    public GameObject crowdStart;
    public GameObject crowdEnd;

    // Use this for initialization
    public void Generate () {
        int b = 0;

        for (float i = crowdStart.transform.localPosition.x; i < crowdEnd.transform.localPosition.x; i += density) {
            for (float j = crowdStart.transform.localPosition.y; j < crowdEnd.transform.localPosition.y; j += density) {
                
                Vector3 position = new Vector3(i + Random.Range(-variance, variance), j + Random.Range(-variance, variance), 0);
                
                GameObject personObject = Instantiate(
                    person,
                    gameObject.transform
                );
                personObject.transform.localPosition = position;
                // personObject.transform.LookAt(new Vector3(position.x, position.z, 0));

                GameManager.Instance.addToCrowd(personObject);
                b += 1;
            }
        }

        print(b);
	}
}
