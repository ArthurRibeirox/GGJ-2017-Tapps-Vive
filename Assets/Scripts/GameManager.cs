using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool gameEnded;
    private List<GameObject> crowd;
    private List<bool> boredCrowd;
    private float time;
    private int score;
    private int dificulty;

	// Use this for initialization
	void Start () {
        dificulty = 0;
        time      = 0;
        score     = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameEnded)
        {
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                int randomNumber = Random.Range(0, crowd.Count - 1);
                crowd[randomNumber].GetComponent<CrowdAnimation>().startBoring();
                time -= 2;
            }
        }

    }

    private static GameManager instance;

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
        print(score);
    }

    public bool gameHasEnded()
    {
        return gameEnded;
    }

    public void setCrowd(List<GameObject> crowd)
    {
        this.crowd = crowd;
        for(int i = 0; i < crowd.Count; i++)
        {
            boredCrowd.Add(false);
        }
    }

    public void addScore(int points)
    {
        score += points;
    }

}
