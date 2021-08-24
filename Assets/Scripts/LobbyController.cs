using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{

    public GameObject PauseMenuPanel;
    public GameObject GameOverPanel;
    public GameObject SettingsPanel;
    public GameObject StartButtonsPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PauseMenuPanel.SetActive(true);
        }

        if (PlayerController.obstaclesPassed == 3)
        {
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
            PlayerController.obstaclesPassed = 0;
        }
    }

    public void StartButton()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        BulletController.score = 0;
    }

    public void QuitButton()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        Application.Quit();
    }

    public void ResumeButton()
    {
        //code
        FindObjectOfType<SoundManager>().Play("Click");
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void MainMenuButton()
    {
        FindObjectOfType<SoundManager>().Play("Click");
        SceneManager.LoadScene(0);
    }

    public void SettingsButton()
    {
        StartButtonsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackButton()
    {
        StartButtonsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
