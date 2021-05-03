using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;

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

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
