using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
    public bool bored = false;
    public float time = 0;

	string[] animations = { "jump" }; 
    string[] idleAnimations = {"idle"};

    private Animator animator;
    
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = Random.Range(0.8f, 1);

        int index = Random.Range(0, idleAnimations.Length) + 1;
        animator.SetInteger("Idle", index);
        animator.SetTrigger("StartAnimation");
	}
	

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered");
        if(bored == true)
        {
            GameManager.Instance.addScore(50);
        }
        bored = false;

        int index = Random.Range(0, animations.Length) + 1;
        int index2 = Random.Range(0, idleAnimations.Length) + 1;
        animator.SetInteger("Celebration", index);
        animator.SetInteger("Idle", index2);
        animator.SetTrigger("ChangeAnimation");
    }


    public void startBoring(){
        bored = true;
    }


    void Update(){
        time += Time.deltaTime;
        if(bored == true && animations.Length < time) {
            int index = Random.Range(0, animations.Length);
            gameObject.GetComponent<Animation>().Play(animations[index]);
            gameObject.GetComponent<Animation>().PlayQueued("idle");
            time = 0;
        }
    }
}
