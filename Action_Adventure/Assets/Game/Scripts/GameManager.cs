using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Character playerCharacter;
    private bool gameIsOver;
    public AudioSource audioSource;
    public GameUI gameUI_manager;
    public float freezeDelay = 2f;

    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    private void GameOver()
    {
        gameUI_manager.ShowGameOver();

        StartCoroutine(FreezeGameAfterDelay(freezeDelay));

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }
    }
    private IEnumerator FreezeGameAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Freeze the game by setting time scale to 0
        Time.timeScale = 0f;
    }

    public void GameIsFinished()
    {
        gameUI_manager.ShowGameFinished();

        //Time.timeScale = 0f;
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameUI_manager.TogglePauseUI();
        }

        if (playerCharacter.CurrentState == Character.CharacterState.Dead)
        {
            gameIsOver = true;
            GameOver();
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
