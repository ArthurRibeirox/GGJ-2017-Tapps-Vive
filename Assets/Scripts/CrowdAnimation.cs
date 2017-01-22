using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
    public bool bored = false;
    public float time = 0;
    private bool leaving = false;
    private bool leaved = false;
    private GameObject fan = null;
    private Vector3 initialPosition;

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
            if (leaving)
            {
                print("start animation");
                animator.Play("Staying", -1, time);
            }

        }

        bored = false;
        leaving = false;
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
        Transform parent = gameObject.transform.parent;
        initialPosition = parent.position;
        time = 0;
    }


    void Update(){
        // Vector3 headPos = GameManager.Instance.head.transform.position;
        // transform.LookAt(new Vector3(headPos.x, transform.position.y, headPos.z));

        if (bored && !leaving)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                GameManager.Instance.removeFromCrowd(transform.parent.gameObject);
                leaving = true;
                animator.SetTrigger("Leave");
                time = 0;     
            }
        }
        else if (leaving && !animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            time += Time.deltaTime;
            //if (Input.GetMouseButtonDown(0) && !leaved)
            //{
            //    print("start animation");
            //    print(animator.playbackTime);
            //    animator.Play("Staying",-1,time);
            //    time = 0;
            //    leaving = false;
            //    bored = false;
            //}
            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                
                leaved = true;
                Object.Destroy(gameObject);
                //fan.transform.position = Vector3.MoveTowards(fan.transform.position, initialPosition, Time.deltaTime * 2);
                //leaving = false;
                //bored = false;
                //time = 0;
            }
            else
            {
                //fan.transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
            }
        }
    }
}
