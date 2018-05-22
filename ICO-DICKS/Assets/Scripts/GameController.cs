using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject EndCam;
    bool isInstantiated;
    bool isTied;
    public bool isPaused;

    int wins1;
    int wins2;


    public GameObject gameCanvas;
    public GameObject endGameCanvas;
    public GameObject P1Canvas;
    public GameObject P2Canvas;

    public GameObject PauseCanvas;

	void Start () {
        isPaused = false;
	}
	
	void Update () {
        if (isInstantiated == false)
        {
            if (!FindObjectOfType<PlayerController1>() && !FindObjectOfType<PlayerController2>())
            {
                isTied = true;
                gameCanvas.SetActive(false);
                endGameCanvas.SetActive(true);
                Instantiate(EndCam, transform.position, Quaternion.Euler(90, 0, 0));
                isInstantiated = true;
                P2Canvas.SetActive(false);
                P1Canvas.SetActive(false);
            }

            Pause();
        }

        if (!FindObjectOfType<PlayerController1>() && isTied == false)
        {
            if (isTied == false)
            {
                gameCanvas.SetActive(false);
                P2Canvas.SetActive(true);
                wins1 = wins1 + 1;
            }
        }

        if (!FindObjectOfType<PlayerController2>() && isTied == false)
        {
            if (isTied == false)
            {
                gameCanvas.SetActive(false);
                P1Canvas.SetActive(true);

                wins2 = wins2 + 1;
            }
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
