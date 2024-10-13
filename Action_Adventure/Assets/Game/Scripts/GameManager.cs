using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Character playerCharacter;
    private bool gameIsOver;
    public AudioSource audioSource;

    private void Awake()
    {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio when game is over
        }
    }

    public void GameIsFinished()
    {
        Debug.Log("Game Finished");
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio when game is over
        }
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (playerCharacter.CurrentState == Character.CharacterState.Dead)
        {
            gameIsOver = true;
            GameOver();
        }
    }
}
