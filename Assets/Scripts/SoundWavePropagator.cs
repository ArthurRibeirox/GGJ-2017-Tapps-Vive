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
    private Renderer renderer;


    void Awake ()
    {
        child.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        rotVel = new Vector3(0, 0, Random.value > 0.5f ? -1.3f : 1.3f);
        renderer = child.GetComponent<Renderer>();
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

        Color color = renderer.material.GetColor("_TintColor");
        renderer.material.SetColor("_TintColor", new Color(color.r, color.g, color.b, 0.9f - curLife / life));

        transform.localScale += expansion;
        transform.position += direction * velocity;
    }
}
