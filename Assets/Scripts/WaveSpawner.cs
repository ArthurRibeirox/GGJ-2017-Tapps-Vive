using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public GameObject headSpawnPoint;
    public GameObject headWave;
    public Vector3 headDirection;

    public GameObject stringsSpawnPoint;
    public GameObject stringsWave;

    public void SpawnHead () {
        Vector3 direction = transform.TransformDirection(headDirection);
        GameObject wave = Instantiate(
            headWave,
            headSpawnPoint.transform.position,
            Quaternion.LookRotation(direction)
        );

        SoundWavePropagator propagator = wave.GetComponent<SoundWavePropagator>();
        propagator.direction = direction;
    }

    public void SpawnStrings () {
        print("Spawn");
    }
}
