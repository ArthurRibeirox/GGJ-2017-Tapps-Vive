using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {
    [FMODUnity.EventRef]
    public string baseSound = "event:/Base";
    [FMODUnity.EventRef]
    public string soloSound = "event:/Solo";
    FMOD.Studio.EventInstance soloEventInstance;
    FMOD.Studio.EventInstance baseEventInstance;
    private float volume;
    private float time;

    // Use this for initialization
    void Start ()
    {
        baseEventInstance = FMODUnity.RuntimeManager.CreateInstance(baseSound);
        soloEventInstance = FMODUnity.RuntimeManager.CreateInstance(soloSound);
        baseEventInstance.start();
        soloEventInstance.setVolume(0f);
        soloEventInstance.getVolume(out volume);
        soloEventInstance.start();
        time = 0f;
        
        


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            soloEventInstance.setVolume(Mathf.Min(1, volume + 0.3f));
            soloEventInstance.getVolume(out volume);
        }


        time += Time.deltaTime;
        print(time);
        if (time > 1)
        {
            soloEventInstance.setVolume(Mathf.Max( volume - 0.3f,0));
            soloEventInstance.getVolume(out volume);
            time = time - 1;
        }
	}
}
