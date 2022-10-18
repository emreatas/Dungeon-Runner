using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _deadPanel;

    private void OnEnable()
    {
        GameManager.Dead += GameManager_Dead;
    }

    private void GameManager_Dead()
    {

        _deadPanel.SetActive(true);
        GameManager.Instance.OnGamePause(true);

    }

    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;

    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void PauseButton(GameObject pausePanel)
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        GameManager.Instance.OnGamePause(true);
    }
    public void ResumeButton(GameObject pausePanel)
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        GameManager.Instance.OnGamePause(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("StartScene");
    }




}
