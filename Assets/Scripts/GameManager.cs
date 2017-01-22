using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    private bool gameEnded;
    static private List<GameObject> crowd;
    private float time;
    private int score;
    private int dificulty;
    public GameObject head;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        crowd     = new List<GameObject>();
        dificulty = 0;
        time      = -2;
        score     = 0;
        gameEnded = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameEnded && crowd.Count > 0)
        {
            time += Time.deltaTime;
            if (time > 3f)
            {
                int randomNumber = Random.Range(0, crowd.Count - 1);
                GameObject obj = crowd[randomNumber];
                if (!obj) return;

                Transform child = obj.transform.GetChild(0);
                if (!child) return;

                child.GetComponent<CrowdAnimation>().startBoring();
                time = 0;
            }
        }

    }

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
        }
    }

    public void endGame()
    {
        gameEnded = true;
        foreach (GameObject person in crowd)
        {
            Object.Destroy(person);
        }
        print(score);
    }

    public bool gameHasEnded()
    {
        return gameEnded;
    }

    public void addToCrowd(GameObject obj)
    {
        crowd.Add(obj);
    }

    public void addScore(int points)
    {
        score += points;
    }

}
