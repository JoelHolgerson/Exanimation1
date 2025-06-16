using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ChangeScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        scoreManager.ResetScore();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
