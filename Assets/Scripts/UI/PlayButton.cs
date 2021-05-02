using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Start()
    {
        _playButton.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        GameManager._isGameStart = true;
        _playButton.gameObject.SetActive(false);
    }
}
