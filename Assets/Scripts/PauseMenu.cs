using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject _joystick;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    private void Start()
    {
        _joystick = GameObject.FindWithTag("Joystick");
    }

    public void Resume()
    {
        _joystick.SetActive(true);
        pauseMenuUI.SetActive(false);
        GameManager.PauseMyGame = false;
        GameManager.SlowMo = false;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            _joystick.SetActive(false);
            pauseMenuUI.SetActive(true);
            GameManager.PauseMyGame = true;
            GameIsPaused = true;
        }
    }

    public void LoadMenu()
    {
        GameManager.PauseMyGame = false;
        GameManager.SlowMo = false;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}