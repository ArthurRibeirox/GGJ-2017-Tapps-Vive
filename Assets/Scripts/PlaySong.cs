using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {
    //[FMODUnity.EventRef]
    //public string baseSound = "event:/Base";
    [FMODUnity.EventRef]
    public string soloSound = "event:/Player_gtr";
    FMOD.Studio.EventInstance soloEventInstance;
    FMOD.Studio.EventInstance baseEventInstance;
    private float volume;
    private float time;

    // Use this for initialization
    void Start ()
    {
        //baseEventInstance = FMODUnity.RuntimeManager.CreateInstance(baseSound);
        soloEventInstance = FMODUnity.RuntimeManager.CreateInstance(soloSound);
        //baseEventInstance.start();
        soloEventInstance.setVolume(0f);
        soloEventInstance.getVolume(out volume);
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
                soloEventInstance.setVolume(Mathf.Max(volume - 0.5f, 0));
                soloEventInstance.getVolume(out volume);
                time = time - 1;
            }
        }
    }

    public void playGuitar()
    {
        soloEventInstance.setVolume(Mathf.Min(1, volume + 0.3f));
        soloEventInstance.getVolume(out volume);
    }

}
