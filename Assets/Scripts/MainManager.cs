using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] 
    private Manager _enemiesManager;
    [SerializeField] 
    private UIManager _uiManager;

    private void Awake()
    {
        _enemiesManager.EnemySpawned += _uiManager.SetEnemiesSpawned;
        _enemiesManager.EnemyDied += _uiManager.SetEnemiesCount;
    }

    private void OnDestroy()
    {
        _enemiesManager.EnemyDied -= _uiManager.SetEnemiesCount;
        _enemiesManager.EnemySpawned -= _uiManager.SetEnemiesSpawned;
    }
}
