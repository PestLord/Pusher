using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeController : MonoBehaviour
{
    private Manager _gameManager;
    private Color _currentColor;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<Manager>();
        Rebuild();
    }

    void Rebuild()
    {
        _currentColor = _gameManager.ChangeColor(gameObject);
        GetComponent<Renderer>().material.color = _currentColor;
        GetComponent<Transform>().position = _gameManager.ChangePosition(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Renderer>().material.color = _currentColor;
            Rebuild();           
        }

    }
    

}
