using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject EndCam;
    bool isInstantiated;

    public GameObject gameCanvas;
    public GameObject endGameCanvas;

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
            }
        }
	}

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
