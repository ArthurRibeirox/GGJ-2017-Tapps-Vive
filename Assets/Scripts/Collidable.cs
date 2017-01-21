using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {
    public float vibrationVariance;
    public int numVibrations;
    private int curVibration;

    private Vector3 nextScale;
    private Vector3 previousScale;
    private float curVibrationTime;
    public float vibrationDuration;
    private Vector3 defaultScale;

    // Use this for initialization
    void Start () {
        this.enabled = false;
        defaultScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        curVibrationTime += Time.deltaTime;

        if (curVibrationTime < vibrationDuration)
        {
            transform.localScale = Vector3.Lerp(previousScale, nextScale, curVibrationTime/vibrationDuration);
        }
        else
        {
            curVibrationTime = 0;
            previousScale = nextScale;
            if (curVibration >= numVibrations)
            {
                this.enabled = false;
                return;
            }

            if (curVibration + 1 == numVibrations)
                nextScale = defaultScale;
            else
                /*nextScale = new Vector3(
                    previousScale.x + Random.Range(-vibrationVariance, vibrationVariance),
                    previousScale.y + Random.Range(-vibrationVariance, vibrationVariance),
                    previousScale.z + Random.Range(-vibrationVariance, vibrationVariance)
                );*/

                nextScale = new Vector3(
                    previousScale.x,
                    previousScale.y + Random.Range(0, vibrationVariance),
                    // previousScale.y + 1,
                    previousScale.z
                );

            curVibration += 1;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        previousScale = defaultScale;
        nextScale = defaultScale;
        curVibrationTime = vibrationDuration + 10;
        this.enabled = true;
    }
}
