using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    [SerializeField] private int _enemyCount = 6;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _sphere;

    [SerializeField] private GameObject _gameBoard;
    private float _boardSize;
    
    private void Awake()
    { 
        _boardSize = _gameBoard.transform.localScale.x;
        for (int i = 0; i < _enemyCount; i++)
        {
            Instantiate(_enemy);
        }

        Instantiate(_sphere);
    }
    
    public Vector3 ChangePosition()
    {
       return new Vector3(Random.Range(-_boardSize*5, _boardSize*5), 1,
            Random.Range(-_boardSize*5, _boardSize*5));
    }

    public Color ChangeColor()
    {
        return _colors[Random.Range(0, _colors.Length)];
    }
}
