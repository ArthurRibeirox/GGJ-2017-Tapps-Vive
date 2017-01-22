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


    public void startBoring() {
        bored = true;
        animator.SetTrigger("Bore");
        time = 0;
    }


    void Update(){
        // Vector3 headPos = GameManager.Instance.head.transform.position;
        // transform.LookAt(new Vector3(headPos.x, transform.position.y, headPos.z));

        if (bored)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                GameManager.Instance.removeFromCrowd(transform.parent.gameObject);
                Object.Destroy(gameObject);
            }
        }
    }
}
