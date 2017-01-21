using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
	string[] animations = { "Celebration" }; 
    string[] idleAnimations = {"Idle", "Idle2"};

    private Animator animator;

    
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        animator.speed = Random.Range(0.8f, 1);

        int index = Random.Range(0, idleAnimations.Length);
        animator.SetInteger("Idle", index);
        animator.SetTrigger("StartAnimation");
	}
	

    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, animations.Length);
        int index2 = Random.Range(0, idleAnimations.Length);
        animator.SetInteger("Celebration", index);
        animator.SetInteger("Idle", index2);
        animator.SetTrigger("ChangeAnimation");
    }
}
