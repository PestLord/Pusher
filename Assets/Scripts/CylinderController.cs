using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    private Manager _manager;
    private Color _currentColor;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<Manager>();
        Rebuild();
    }
    
    void Rebuild()
    {
        _currentColor = _manager.ChangeColor(gameObject);
        GetComponent<Renderer>().material.color = _currentColor;
        transform.position = _manager.ChangePosition(gameObject);
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Renderer>().material.color == _currentColor && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
