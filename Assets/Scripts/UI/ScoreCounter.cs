using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _hiScoreText;

    private float _time = 0.08f;
    private int _score;
    private const string HI_Score_Key = "hiScore";
    private int _hiScore;

    private void Start()
    {
        _scoreText.text = $"{_score}";

        GetHiScore();
        StartCoroutine(Count());
    }

    private void Update()
    {
        if (GameManager._isGameStop)
        {
            SetHiScore();
        }
    }

    private void GetHiScore()
    {
        if (PlayerPrefs.HasKey(HI_Score_Key) == false)
        {
            PlayerPrefs.SetInt(HI_Score_Key, 0);
        }
        else
        {
            _hiScore = PlayerPrefs.GetInt(HI_Score_Key);
        }

        _hiScoreText.text = $"HI {_hiScore}";
    }

    private void SetHiScore()
    {
        if (_hiScore < _score)
        {
            PlayerPrefs.SetInt(HI_Score_Key, _score);
        }
    }

    IEnumerator Count()
    {
        while (GameManager._isGameStop == false)
        {
            if (GameManager._isGameStart)
            {
                _score++;
                _scoreText.text = $"{_score}";
                _hiScoreText.text = $"HI {_hiScore}";
            }

            yield return new WaitForSeconds(_time);
        }
    }
}