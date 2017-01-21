using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
	string[] animations = { "applause", "applause2", "celebration", "celebration2", "celebration3" }; 

    
	void Start () {
		gameObject.GetComponent<Animation>()["idle"].wrapMode = WrapMode.Loop;
	}
	

    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, animations.Length);
        gameObject.GetComponent<Animation>().Play(animations[index]);
        gameObject.GetComponent<Animation>().PlayQueued("idle");
    }
}
