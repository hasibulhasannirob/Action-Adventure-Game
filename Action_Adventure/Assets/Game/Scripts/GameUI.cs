using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameManager GM;
    public Slider HealthSlider;
    public GameObject UI_Pause;
    public GameObject UI_GameOver;
    public GameObject UI_GameFinished;

    private enum GameUIState
    {
        GamePlay, Pause, GameOver, GameFinished
    }

    GameUIState currentState;

    private void Start()
    {
        SwitchUIState(GameUIState.GamePlay);
    }

    void Update()
    {
        HealthSlider.value = GM.playerCharacter.GetComponent<Health>().CurrentHealthPercentage;
    }

    private void SwitchUIState(GameUIState state)
    {
        UI_Pause.SetActive(false);
        UI_GameOver.SetActive(false);
        UI_GameFinished.SetActive(false);

        Time.timeScale = 1;

        switch (state)
        {
            case GameUIState.GamePlay:
                break;
            case GameUIState.Pause:
                Time.timeScale = 0;
                UI_Pause.SetActive(true);
                break;
            case GameUIState.GameOver:
                UI_GameOver.SetActive(true);
                break;
            case GameUIState.GameFinished:
                UI_GameFinished.SetActive(true);
                break;
        }

        currentState = state;
    }

    public void TogglePauseUI()
    {
        if (currentState == GameUIState.GamePlay)
        {
            SwitchUIState(GameUIState.Pause);
        }
        else if (currentState == GameUIState.Pause)
        {
            SwitchUIState(GameUIState.GamePlay);
        }
    }

    public void Button_MainMenu()
    {
        GM.ReturnToMainMenu();
    }

    public void Button_Restart()
    {
        GM.Restart();
    }

    public void ShowGameOver()
    {
        SwitchUIState(GameUIState.GameOver);
        
    }

    public void ShowGameFinished()
    {
        SwitchUIState(GameUIState.GameFinished);
        
    }
}
