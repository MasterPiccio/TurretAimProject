using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    UIController uIController;
    Spawner spawner;
    Cannon player;
    private int Difficulty=1;
    public int difficulty {get {return Difficulty;} set {Difficulty = value;}} 

    private int Score=0;

    int killedEnemies =0;
    public int totalKilledEnemies {get {return killedEnemies;}set{ killedEnemies =value;}}

    public int score {get{return Score;} set{Score = value; } }

    // Start is called before the first frame update
    void Start()
    {
        uIController= FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
        player =FindObjectOfType<Cannon>();
        uIController.ShowTutorialPanel();
        PauseGame();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.isdead)
        {
            endGame();
        }
    }



    public void SetDifficulty(string _selection)
    
    {
        switch(_selection)
        {
            case "Easy":
                difficulty = 1;
                break;
            case "Medium":
                difficulty = 3;
                break;
            case "Hard":
                difficulty = 5;
                break;
            case "Hardest":
                difficulty = 10;
                break;
        }
    }

    public void StartGame()
    {
        Time.timeScale =1;
        uIController.HidePanels();
        uIController.ShowGamePanel();
    }

    public void PauseGame()
    {
        Time.timeScale =0;
    }

    public void IncreaseScore(int _value)
    {
        score += _value;
        killedEnemies++;
    }

    public void endGame()
    {
        PauseGame();
        uIController.ShowEndGamePanel();
    }
}
