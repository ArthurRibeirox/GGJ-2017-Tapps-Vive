using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
    public bool bored = false;
    public float time = 0;

	string[] animations = { "jump" }; 
    string[] idleAnimations = {"idle"};
    string[] boreAnimations = {"bore"};

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
        if(bored == true)
        {
            GameManager.Instance.addScore(50);
        }

        bored = false;
        time = 0;

        int index = Random.Range(0, animations.Length) + 1;
        int index2 = Random.Range(0, idleAnimations.Length) + 1;
        animator.SetInteger("Celebration", index);
        animator.SetInteger("Idle", index2);
        animator.SetTrigger("ChangeAnimation");
    }


    public void startBoring(){
        bored = true;
        print("is bored");
        int index = Random.Range(0, boreAnimations.Length) + 1;
        animator.SetInteger("Bore", index + 1);
        animator.SetTrigger("ChangeAnimation");
        time = 0;
    }


    void Update(){
        if (bored==true)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                print("vazou");
                Object.Destroy(gameObject);
            }
        } else
        {
            time = 0;
        }
    }
}
