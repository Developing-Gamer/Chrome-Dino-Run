using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void GameOver()
    {
        ShowOverPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
