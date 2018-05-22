﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject EndCam;
    bool isInstantiated;
    bool isTied;

    public GameObject gameCanvas;
    public GameObject endGameCanvas;
    public GameObject P1Canvas;
    public GameObject P2Canvas;

	void Start () {
		
	}
	
	void Update () {
        if (isInstantiated == false)
        {
            if (!FindObjectOfType<PlayerController1>() && !FindObjectOfType<PlayerController2>())
            {
                gameCanvas.SetActive(false);
                endGameCanvas.SetActive(true);
                Instantiate(EndCam, transform.position, Quaternion.Euler(90, 0, 0));
                isInstantiated = true;
                P2Canvas.SetActive(false);
                P1Canvas.SetActive(false);
                isTied = true;
            }
        }

        if (!FindObjectOfType<PlayerController1>())
        {
            if (isTied == false)
            {
                gameCanvas.SetActive(false);
                P2Canvas.SetActive(true);
            }
        }

        if (!FindObjectOfType<PlayerController2>())
        {
            if (isTied == false)
            {
                gameCanvas.SetActive(false);
                P1Canvas.SetActive(true);
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
}
