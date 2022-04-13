using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
