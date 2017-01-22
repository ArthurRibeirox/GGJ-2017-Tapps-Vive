
using UnityEngine;
using VRTK;

public class WaveTrigger : MonoBehaviour
{
    public CrowdGenerator[] scripts;

    private void Start()
    {
        GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerPress);
    }

    private void DoTriggerPress(object sender, ControllerInteractionEventArgs e)
    {

        scripts[2].Generate();
        // foreach (CrowdGenerator script in scripts)
        // {
        //     script.Generate();
        // }
    }
}