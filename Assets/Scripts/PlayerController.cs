using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;
    private Vector3 vector3;
    private Vector3 _playerPosition;

    [SerializeField] private GameObject _forcePoint;
    [SerializeField] private float _forceMultiplicator;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _maxForce;

    private Vector3 hitPos;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePosition = Input.mousePosition;
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
                _playerPosition = GetComponent<Transform>().localPosition;
                hitPos = hit.transform.position;
                vector3 = hit.point - _playerPosition;
                var distance = Mathf.Sqrt(Mathf.Pow(vector3.x, 2) + Mathf.Pow(vector3.z, 2));
                var minimum = Mathf.Min(distance * _forceMultiplicator, _maxForce);
                _rigidbody.AddForce(vector3.normalized * minimum);
            }
        }
    }
}
