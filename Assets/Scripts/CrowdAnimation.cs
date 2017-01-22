using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour {
    public bool bored = false;
    public float time = 0;
    private bool leaving = false;
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


    public void startBoring(GameObject gmObject) {
        bored = true;
        animator.SetTrigger("Bore");
        fan = gmObject;
        initialPosition = gmObject.transform.position;
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
        else if (leaving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("start animation");
                animator.speed = -1;
                time = 0;
                leaving = false;
                bored = false;
            }
                time += Time.deltaTime;
            if (time > 3)
            {
                animator.SetTrigger("Leave");
                //Object.Destroy(gameObject);
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
