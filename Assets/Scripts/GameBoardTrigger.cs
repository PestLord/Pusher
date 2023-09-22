using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        Debug.Log("exit");
        // Если попавший в триггер объект - это Player.
        if (player)
        {
            // Перемещаем его к начальной точке.
            player.MoveToStartPoint();
        }
    }
}
