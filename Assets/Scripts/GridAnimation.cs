using UnityEngine;

public class GridAnimation : MonoBehaviour
{
    private Animator _gridAnimator;
    void Start()
    {
        _gridAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager._isGameStop || GameManager._isGameStart == false)
        {
            _gridAnimator.enabled = false;
        }
        else
        {
            _gridAnimator.enabled = enabled;
        }
    }
}
