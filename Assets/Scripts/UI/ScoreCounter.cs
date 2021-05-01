using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private float _time = 0.08f;
    private int _score;

    private void Start()
    {
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        while (true)
        {
            _score++;
            _scoreText.text = $"{_score}";
            yield return new WaitForSeconds(_time);
        }
    }
}
