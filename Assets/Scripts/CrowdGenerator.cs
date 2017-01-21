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
    static public List<GameObject> crowd;
    public CrowdAnimation crowdAnimation;
    public GameObject personObject;
    static public bool ended;
    public float time;

    // Use this for initialization
    void Start () {
        ended = false;
        crowd = new List<GameObject>();
        int b = 0;
        time = 0;

        for (float i = crowdStart.transform.position.x; i < crowdEnd.transform.position.x; i += density) {
            for (float j = crowdStart.transform.position.z; j < crowdEnd.transform.position.z; j += density)
            {
                if (i*i + j*j <= radius) continue;
                
                Vector3 position = new Vector3(i + Random.Range(-variance, variance), -1.67f, j + Random.Range(-variance, variance));

                personObject = Instantiate(
                    person,
                    position,
                    Quaternion.LookRotation(new Vector3(-position.x, 0, -position.z))
                );
                crowd.Add(personObject);
                b += 1;
            }
        }

        print(b);

	}

    // Update is called once per frame
    void Update()
    {
        if (!ended) { 
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                print("ficou entediado");
                int randomNumber = Random.Range(0, crowd.Count - 1);
                print(randomNumber);
                crowd[randomNumber].GetComponent<CrowdAnimation>().startBoring();
                time -= 2;
            }
        }
	}

    public static void endGame()
    {
        ended = true;
        foreach(GameObject person in crowd){
            Object.Destroy(person);
        }
    }
}
