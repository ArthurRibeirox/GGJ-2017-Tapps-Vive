using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;

    public List<GameObject> crowd;
    private bool gameEnded;
    private bool gameStarted = false;
    private float time;
    private int score;

    public float boreRate = 0.5f;
    public int boreCount = 10;
    public float boreRadius = 3;


    public TextMesh textObject;
    public TextMesh scoreText;
    public GameObject head;

    public CrowdGenerator[] scripts;
    public PlaySong playSong;

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
        time      = 5;
        score     = 0;
        gameEnded = false;
        textObject.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameStarted) {
            time -= Time.deltaTime;

            textObject.text = Mathf.Ceil(time).ToString();
            if (time < 0) {
                time = -2;
                startGame();
            }
        }
        else if (!gameEnded && crowd.Count > 0)
        {
            time += Time.deltaTime;
            if (time > boreRate)
            {
                print("will bore!");
                time = 0;

                int randomNumber = Random.Range(0, crowd.Count - 1);
                GameObject obj = crowd[randomNumber];
                if (obj == null || obj.transform.childCount == 0) return;

                Transform child = obj.transform.GetChild(0);
                if (child == null) return;

                TriggerBored(child);

                int layerMask = 1 << 8;
                Collider[] hitColliders = Physics.OverlapSphere(obj.transform.position, boreRadius, layerMask);

                int[] iterator = createShuffleArray(hitColliders.Length);

                for (int i = 0; i < hitColliders.Length && i < boreCount; i++) {
                    int index = iterator[i];

                    TriggerBored(hitColliders[index].gameObject.transform);
                }
            }
        }
    }

    private GameManager() { }

    public int[] createShuffleArray(int length) {

        int [] arr = new int[length];
        for (int i = 0; i < length; i++)
            arr[i] = i;

        for (int i = arr.Length - 1; i > 0; i--) {
            int r = Random.Range(0, i);
            int tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }

        return arr;
    }

    void TriggerBored(Transform child) {
        CrowdAnimation script = child.GetComponent<CrowdAnimation>();
        if (script == null) return;

        script.startBoring();
    }



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


    public void startGame()
    {
        scoreText.gameObject.GetComponent<Renderer>().enabled = true;
        gameStarted = true;
        playSong.StartSong();
        foreach (CrowdGenerator script in scripts)
        {
            script.Generate();
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
