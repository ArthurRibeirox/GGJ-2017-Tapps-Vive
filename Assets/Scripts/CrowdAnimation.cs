using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
    public bool bored;
    public float time;
	string[] animations = { "applause", "applause2", "celebration", "celebration2", "celebration3" }; 

    
	void Start () {
        bored = false;
        time = 0;
		gameObject.GetComponent<Animation>()["idle"].wrapMode = WrapMode.Loop;
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if(bored == true)
        {
            GameManager.Instance.addScore(50);
        }
        bored = false;
        int index = Random.Range(0, animations.Length);
        gameObject.GetComponent<Animation>().Play(animations[index]);
        gameObject.GetComponent<Animation>().PlayQueued("idle");
    }

    public void startBoring(){
        bored = true;

    }

    void Update(){
        time += Time.deltaTime;
        if(bored == true && animations.Length < time){
        int index = Random.Range(0, animations.Length);
        gameObject.GetComponent<Animation>().Play(animations[index]);
        gameObject.GetComponent<Animation>().PlayQueued("idle");
        time = 0;
        }
    }
}
