using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool _isGameStop { get; set; }
    public static bool _isGameStart { get; set; }
    
    private void Start()
    {
        _isGameStop = false;
        _isGameStart = false;
    }
}
