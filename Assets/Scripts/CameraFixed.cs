using System;
using UnityEngine;

public class CameraFixed : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    private void Update()
    {
        transform.position = new Vector3(playerPosition.position.x, 0);
    }
}
