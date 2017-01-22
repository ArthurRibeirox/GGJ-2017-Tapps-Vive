using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;

    public List<GameObject> crowd;
    private bool gameEnded;
    private float time;
    private int score;

    public float boreRate = 0.5f;


    public TextMesh textObject;
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
        time      = -2;
        score     = 0;
        gameEnded = false;
        textObject.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameEnded && crowd.Count > 0)
        {
            time += Time.deltaTime;
            if (time > boreRate)
            {
                time = 0;

                int randomNumber = Random.Range(0, crowd.Count - 1);
                GameObject obj = crowd[randomNumber];
                if (obj == null || obj.transform.childCount == 0) return;

                Transform child = obj.transform.GetChild(0);
                if (child == null) return;

                CrowdAnimation script = child.GetComponent<CrowdAnimation>();
                if (script == null) return;

                script.startBoring();
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

    public void removeFromCrowd(GameObject obj)
    {
        crowd.Remove(obj);
    }

    public void addScore(int points)
    {
        score += points;
        textObject.text = score.ToString();
    }

}
