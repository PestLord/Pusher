using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    [SerializeField] private int _enemyCount = 6;

    [SerializeField] private ColorChangeController _colorChangeController;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _sphere;

    [SerializeField] private CylinderController _cylinderController;
    [SerializeField] private GameObject _gameBoard;
    private float _boardSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    { 
        _boardSize = _gameBoard.transform.localScale.x;
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_enemy);
        }

        Instantiate(_sphere);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ExitTrigger");
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 0.5f, 1);Ф
        }
    }

    public Vector3 ChangePosition(GameObject gameObject)
    {
       return new Vector3(Random.Range(-_boardSize*5, _boardSize*5), 1,
            Random.Range(-_boardSize*5, _boardSize*5));
    }

    public Color ChangeColor(GameObject gameObject)
    {
        return gameObject.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length)];
    }
}
