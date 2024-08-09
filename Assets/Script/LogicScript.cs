using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text textScore;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public AudioSource gameOverSFX;
    public float timer = 0;


    private void Start()
    {
        dingSFX.volume = 0.1f;
        gameOverSFX.volume = 0.1f;
    }

    //context menu for control handy in unity
    [ContextMenu("Increase Score")]
    public void AddScore()
    {
            playerScore += 1;
            textScore.text = playerScore.ToString();
            dingSFX.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
            gameOverScreen.SetActive(true);
            gameOverSFX.Play();
    }

    
}
