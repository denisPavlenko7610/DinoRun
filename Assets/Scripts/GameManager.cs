using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool _isGameStop { get; set; }

    private void Start()
    {
        _isGameStop = false;
    }
}
