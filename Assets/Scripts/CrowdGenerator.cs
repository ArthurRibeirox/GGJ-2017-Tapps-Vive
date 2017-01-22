using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdGenerator : MonoBehaviour {
    public float density = 1;
    public float variance = 0.1f;
    public GameObject[] prefabs;
    public GameObject crowdStart;
    public GameObject crowdEnd;

    // Use this for initialization
    public void Generate () {
        print("Generating");
        int b = 0;

        for (float i = crowdStart.transform.localPosition.x; i < crowdEnd.transform.localPosition.x; i += density) {
            for (float j = crowdStart.transform.localPosition.y; j < crowdEnd.transform.localPosition.y; j += density) {
                
                Vector3 position = new Vector3(i + Random.Range(-variance, variance), j + Random.Range(-variance, variance), 0);
                
                int index = Random.Range(0, prefabs.Length);

                GameObject personObject = Instantiate(
                    prefabs[index]
                );
                personObject.transform.position = transform.TransformPoint(position);

                Vector3 headPos = GameManager.Instance.head.transform.position;
                personObject.transform.LookAt(new Vector3(headPos.x, personObject.transform.position.y, headPos.z));

                if (Random.value > 0.5f) {
                    Transform child = personObject.transform.GetChild(0);
                    child.GetComponent<SpriteRenderer>().flipX = true;
                }

                GameManager.Instance.addToCrowd(personObject);
                b += 1;
            }
        }

        print(b);
	}
}
