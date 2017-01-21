using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWavePropagator : MonoBehaviour {

    public float velocity;
    public Vector3 direction;
    public Vector3 expansion;

    public float jitterTime = 0.1f;
    public float jitterVariance = 0.2f;
    public GameObject child;
    private float curJitterTime = 0.3f;

    public float life;
    private float curLife;

    public float rotVelVariance = 20;
    private Vector3 rotVel;
    private Material material;


    void Awake ()
    {
        child.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        rotVel = new Vector3(0, 0, Random.value > 0.5f ? -1.3f : 1.3f);
        material = child.GetComponent<Renderer>().material;
    }


	// Update is called once per frame
	void Update ()
    {
        curLife += Time.deltaTime;
        if (curLife > life)
            Destroy (gameObject);

        if (curLife > curJitterTime)
            child.transform.localScale = Vector3.one * (1 - Random.Range(0, jitterVariance));

        child.transform.Rotate(rotVel);



        // material.color = new Color(material.color.r, material.color.g, material.color.b, 255 * curLife / life);

        transform.localScale += expansion;
        transform.position += direction * velocity;
    }
}
