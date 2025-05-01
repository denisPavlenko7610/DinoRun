using UnityEngine;

public class ParallaxBackground_0 : MonoBehaviour
{
    [Header("Layer Setting")] 
    public float[] Layer_Speed = new float[7];
    public GameObject[] Layer_Objects = new GameObject[7];

    private Transform _camera;
    private float[] _startPositions;
    private float _boundSizeX;
    private float _sizeX;

    void Start()
    {
        _camera = Camera.main.transform;
        _sizeX = Layer_Objects[0].transform.localScale.x;
        _boundSizeX = Layer_Objects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        _startPositions = new float[Layer_Objects.Length];
        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            _startPositions[i] = _camera.position.x;
        }
    }

    void Update()
    {
        for (int i = 0; i < Layer_Objects.Length; i++)
        {
            float parallaxEffect = Layer_Speed[i];
            float temp = (_camera.position.x * (1 - parallaxEffect));
            float distance = _camera.position.x * parallaxEffect;

            Layer_Objects[i].transform.position = new Vector2(_startPositions[i] + distance, _camera.position.y);

            if (temp > _startPositions[i] + _boundSizeX * _sizeX)
            {
                _startPositions[i] += _boundSizeX * _sizeX;
            }
            else if (temp < _startPositions[i] - _boundSizeX * _sizeX)
            {
                _startPositions[i] -= _boundSizeX * _sizeX;
            }
        }
    }
}