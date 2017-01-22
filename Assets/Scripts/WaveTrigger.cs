
using UnityEngine;
using VRTK;

public class WaveTrigger : MonoBehaviour
{
    public CrowdGenerator[] scripts;
    public PlaySong playSong;

    private void Start()
    {
        print("Started WaveTrigger");
        // GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerPress);
    }

    private void DoTriggerPress(object sender, ControllerInteractionEventArgs e)
    {
        print("trigger pressed");
        GameManager.Instance.enabled = true;
        playSong.StartSong();
        foreach (CrowdGenerator script in scripts)
        {
            script.Generate();
        }
    }
}