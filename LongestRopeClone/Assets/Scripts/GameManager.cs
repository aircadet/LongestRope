using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerState playerState;
    public enum PlayerState 
    {
        Preparing,
        Playing,
        Finish
    }

    private void Update()
    {
        if (playerState == PlayerState.Playing)
        {
            Time.timeScale = 1;
        }
        else 
        {
            Time.timeScale = 0;
        }
    }
    private void Start()
    {
        playerState = PlayerState.Preparing;
    }

    public void StartGame() 
    {
        if (playerState == PlayerState.Preparing) 
        {
            playerState = PlayerState.Playing;
        }
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(0);
    }
}
