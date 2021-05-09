using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private UnityEvent _gameOverEvent;

    private void Start()
    {
        _playButton.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        GameManager._isGameStart = true;
        _playButton.gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        _gameOverEvent?.Invoke();
    }
}
