
using UnityEngine;
using VRTK;

public class WaveTrigger : MonoBehaviour
{
    public WaveSpawner waveSpawnerScript;

    private void Start()
    {
        GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerPress);
        GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPress);
    }

    private void DoTriggerPress(object sender, ControllerInteractionEventArgs e)
    {
    	waveSpawnerScript.SpawnHead();
    }

    private void DoTouchpadPress(object sender, ControllerInteractionEventArgs e)
    {
    	waveSpawnerScript.SpawnStrings();
    }
}