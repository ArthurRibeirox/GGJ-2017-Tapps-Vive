using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickStrokes : MonoBehaviour {
	// public GameObject strings;
	// public GameObject controller;
	// public float maxDistanceStrings;
	// public float maxHeightStrings;

	// private bool onUpSide = false;
	
	// // Update is called once per frame
	// void Update () {
	// 	Vector3 pickPosition = strings.transform.InverseTransformPoint(controller.transform.TransformPoint(controller.transform.position));
	// 	float distance = pickPosition.x*pickPosition.x + pickPosition.y*pickPosition.y;
	// 	float distanceZ = pickPosition.z;

	// 	if(distance > maxDistanceStrings || (distanceZ > maxHeightStrings && distanceZ < -0.1)) return;

	// 	if (onUpSide && pickPosition.y < 0) {
	// 		print("stroke");
	// 		onUpSide = false;
	// 	}
	// 	else if (!onUpSide && pickPosition.y > 0) {
	// 		print("stroke");
	// 		onUpSide = true;
	// 	}
	// }

	public PlaySong playSongScript;
	public WaveSpawner waveSpawnerScript;

    private void OnTriggerEnter(Collider other)
    {
    	playSongScript.playGuitar();
    	waveSpawnerScript.SpawnStrings();
    }
}
