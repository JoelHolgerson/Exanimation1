using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int scoreToWin = 10;

    [SerializeField] TextMeshProUGUI ScoreText;

    int score;

    SceneLoader sceneLoader;

    private void Awake()
    {
        int numberOfScoreManagers = FindObjectsOfType<ScoreManager>().Length;

        if (numberOfScoreManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        ScoreText.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        ScoreText.text = "Score: " + score.ToString();
    }

    public void ScoreAdd()
    {
        if (score == scoreToWin - 1)
        {
            sceneLoader.ChangeScene(3);
            score++;
            ScoreText.text = "Score: " + score.ToString();
        }
        else
        {
            score++;
            ScoreText.text = "Score: " + score.ToString();
        }
    }
}
