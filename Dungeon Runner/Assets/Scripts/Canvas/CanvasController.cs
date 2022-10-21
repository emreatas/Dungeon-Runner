using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject _marketPanel;
    [SerializeField] private TextMeshProUGUI _collectItem;
    [SerializeField] private Image _healthImage;


    private void OnEnable()
    {
        GameManager.Dead += GameManager_Dead;
        GameManager.CollectItem += GameManager_CollectItem;
        GameManager.BuySkill += GameManager_BuySkill;
        GameManager.MarketTile += GameManager_MarketTile;
    }

    private void GameManager_MarketTile()
    {
        _marketPanel.SetActive(true);
        Time.timeScale = 0;
        GameManager.Instance.OnGamePause(true);


    }

    private void GameManager_BuySkill(int obj)
    {
        _collectItem.text = "x" + GameManager.Instance.GetCurrency();
        _marketPanel.SetActive(false);
        Time.timeScale = 1;

        GameManager.Instance.OnGamePause(false);




    }

    private void GameManager_CollectItem()
    {
        _collectItem.text = "x" + GameManager.Instance.GetCurrency();
    }

    private void GameManager_Dead()
    {

        _deadPanel.SetActive(true);
        GameManager.Instance.OnGamePause(true);

    }

    private void OnDisable()
    {
        GameManager.Dead -= GameManager_Dead;
        GameManager.CollectItem -= GameManager_CollectItem;
        GameManager.BuySkill -= GameManager_BuySkill;
        GameManager.MarketTile -= GameManager_MarketTile;



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
