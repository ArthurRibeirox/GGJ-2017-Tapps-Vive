using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {
    //[FMODUnity.EventRef]
    //public string baseSound = "event:/Base";
    [FMODUnity.EventRef]
    public string soloSound = "event:/Player_gtr";
    FMOD.Studio.EventInstance soloEventInstance;
    FMOD.Studio.ParameterInstance shouldPlay; 

    // FMOD.Studio.EventInstance baseEventInstance;
    private float volume;
    private float time;

    // Use this for initialization
    void Start ()
    {
        //baseEventInstance = FMODUnity.RuntimeManager.CreateInstance(baseSound);
        soloEventInstance = FMODUnity.RuntimeManager.CreateInstance(soloSound);
        //baseEventInstance.start();

        soloEventInstance.getParameter("Play", out shouldPlay);
        shouldPlay.setValue(0);
        soloEventInstance.start();
        time = 0f;
    }
    
    // Update is called once per frame
    void Update () {
        if (!GameManager.Instance.gameHasEnded())
        {
            FMOD.Studio.PLAYBACK_STATE playbackState;
            soloEventInstance.getPlaybackState(out playbackState);


            if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED && !GameManager.Instance.gameHasEnded())
            {
                GameManager.Instance.endGame();
            }
            if (Input.GetMouseButtonDown(0))
            {
                playGuitar();
                time = 0;
            }


            time += Time.deltaTime;
            if (time > 1)
            {
                shouldPlay.setValue(0);
                time -= 1;
            }
        }
    }

    public void playGuitar()
    {
        time = 0;
        shouldPlay.setValue(1);
    }

}
