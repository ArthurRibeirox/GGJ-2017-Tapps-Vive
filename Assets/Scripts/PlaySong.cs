using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlaySong : MonoBehaviour {
    public StudioEventEmitter bass;
    public StudioEventEmitter drums;
    public StudioEventEmitter keys;

    [FMODUnity.EventRef]
    public string soloSound = "event:/Player_gtr";
    FMOD.Studio.EventInstance soloEventInstance;
    FMOD.Studio.ParameterInstance shouldPlay;
    public float fadeTime = 0.5f;

    // FMOD.Studio.EventInstance baseEventInstance;
    private float volume;
    private float time;

    // Use this for initialization
    void Start ()
    {
        soloEventInstance = FMODUnity.RuntimeManager.CreateInstance(soloSound);

        soloEventInstance.getParameter("Play", out shouldPlay);
        shouldPlay.setValue(0);

        // // soloEventInstance.set3DAttributes();
        soloEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        time = 0f;
    }


    // Update is called once per frame
    void Update () {
        if (!GameManager.Instance.gameHasEnded())
        {
            FMOD.Studio.PLAYBACK_STATE playbackState;
            soloEventInstance.getPlaybackState(out playbackState);


            // if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED && !GameManager.Instance.gameHasEnded())
            // {
            //     GameManager.Instance.endGame();
            // }
            if (Input.GetMouseButtonDown(0))
            {
                playGuitar();
                time = 0;
            }


            time += Time.deltaTime;
            if (time > fadeTime)
            {
                shouldPlay.setValue(0);
                time = 0;
            }
        }
    }


    public void StartSong() {
        soloEventInstance.start();
        bass.Play();
        drums.Play();
        keys.Play();

        time = 0f;
    }



    public void playGuitar()
    {
        time = 0;
        shouldPlay.setValue(1);
    }

}
