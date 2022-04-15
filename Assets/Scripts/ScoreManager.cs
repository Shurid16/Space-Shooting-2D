using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _highScoreText;

    public static ScoreManager instance;

    void Start()
    {
        instance = this;
        _highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_score == SpawnManager.instance._totalCollectables)
        {
            if (SceneManager.GetActiveScene().name == "3")
            {
                UIManager.instance.ChangeText("Congratulations! You have completed the game");
                UIManager.instance.LoadSceneDelay(0);
            }
            else
            {
                UIManager.instance.ChangeText("You have completed Level " + SceneManager.GetActiveScene().name);
                int level = (Convert.ToInt32(SceneManager.GetActiveScene().name) + 1);
                PlayerPrefs.SetInt(level.ToString(), 1);
                UIManager.instance.LoadSceneDelay(4);
            }
          
            UIManager.instance.ShowGameOverText();
            SpawnManager.instance.StopSpawning();
         

        }
    }

    public void IncreaseScore(int scoreAmount)
    {
        _score += scoreAmount;
        _scoreText.text = _score.ToString();
        if(_score>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            _highScoreText.text = _score.ToString();
        }
       
    }

    public void LoadScne()
    {

    }
}
