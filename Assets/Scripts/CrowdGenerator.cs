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
    public int overrallAnimation;

    // Use this for initialization
    void Start () {
        overrallAnimation = 3;
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
        print(crowd[0].name);
        GameManager.Instance.setCrowd(crowd);

	}

    // Update is called once per frame
    void Update()
    {
        
	}


    public List<GameObject> getCrowd()
    {
        return crowd;
    }
}
