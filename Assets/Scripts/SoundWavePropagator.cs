using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWavePropagator : MonoBehaviour {

    public float velocity;
    public Vector3 direction;
    public Vector3 expansion;
    public float life;
    private float curLife;


	// Update is called once per frame
	void Update ()
    {
        curLife += Time.deltaTime;
        if (curLife > life)
            Destroy (gameObject);

        transform.localScale += expansion;
        transform.position += direction * velocity;
    }
}
