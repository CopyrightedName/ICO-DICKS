using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject buttonPlay;
    public GameObject button1Player;
    public GameObject button2Players;
    public GameObject buttonBack;

    public GameObject maps;
	
	void Start () {
		
	}
	

	void Update () {
		
	}

    public void Play()
    {
        buttonPlay.SetActive(false);
        button1Player.SetActive(true);
        button2Players.SetActive(true);
        buttonBack.SetActive(true);
    }

    public void Back()
    {
        buttonPlay.SetActive(true);
        button1Player.SetActive(false);
        button2Players.SetActive(false);
        buttonBack.SetActive(false);
        maps.SetActive(false);
    }

    public void OnePlayer()
    {

    }

    public void TwoPlayers()
    {
        buttonPlay.SetActive(false);
        button1Player.SetActive(false);
        button2Players.SetActive(false);

        buttonBack.SetActive(true);

        maps.SetActive(true);
    }



    public void Map1()
    {
        SceneManager.LoadScene(2);
    }

    public void Map2()
    {
        SceneManager.LoadScene(2);
    }

    public void Map3()
    {
        SceneManager.LoadScene(2);
    }

    public void Map4()
    {
        SceneManager.LoadScene(2);
    }
}
