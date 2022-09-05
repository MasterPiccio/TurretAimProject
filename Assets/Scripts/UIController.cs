using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    GameController gameController;
    Spawner spawner;
    public GameObject StartPanel;
    public GameObject Difficultypanel;

    public GameObject GamePanel;

    public Text ScoreText;
    public Text EnemyCountText;

    public Text FinalScoreText;
    public Text FinalCountText;
    public GameObject EndGamePanel;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        spawner =FindObjectOfType<Spawner>();


        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScores();
    }



    public void ShowTutorialPanel()
    {

        StartPanel.SetActive(true);
        Difficultypanel.SetActive(false);
        GamePanel.SetActive(false);
        EndGamePanel.SetActive(false);
    }

    public void HideTutorialPanel()
    {
        StartPanel.SetActive(false);
        Difficultypanel.SetActive(true);
    }

    public void HidePanels()
    {
        StartPanel.SetActive(false);
        Difficultypanel.SetActive(false);
    }

    public void ShowGamePanel()
    {
        GamePanel.SetActive(true);

    }

    public void ShowEndGamePanel()
    {
        EndGamePanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    public void UpdateScores()
    {
        ScoreText.text = gameController.score.ToString() + " Points";
        FinalScoreText.text = "Total Score : "+gameController.score;
        EnemyCountText.text = gameController.totalKilledEnemies.ToString()+ " Killed enemies";
        FinalCountText.text = "You Killed "+ gameController.totalKilledEnemies +" enemies";


    }

}
