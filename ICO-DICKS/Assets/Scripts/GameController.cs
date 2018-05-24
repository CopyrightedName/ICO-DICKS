using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject EndCam;
    bool isInstantiated;
    bool isTied;
    public bool isPaused;
    bool hasCounted;

    public int wins1;
    public int wins2;

    public Text winsText1;
    public Text winsText2;

    public GameObject player1;
    public GameObject player2;

    public GameObject gameCanvas;
    public GameObject endGameCanvas;
    public GameObject P1Canvas;
    public GameObject P2Canvas;

    public GameObject PauseCanvas;

	void Start () {
        isPaused = false;
	}
	
	void Update () {
        winsText1.text = "PLAYER 1: " + wins1.ToString();
        winsText2.text = "PLAYER 2: " + wins2.ToString();

        Pause();

        if(wins1 == 5)
        {
            gameCanvas.SetActive(false);
            P1Canvas.SetActive(true);
        }

        if (wins2 == 5)
        {
            gameCanvas.SetActive(false);
            P2Canvas.SetActive(true);
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            PauseCanvas.SetActive(true);
            isPaused = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        PauseCanvas.SetActive(false);
        isPaused = false;
    }
}
