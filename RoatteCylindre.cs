using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoatteCylindre : MonoBehaviour
{
    [SerializeField] private float _maxSpeedRotate;
    [SerializeField] private float _minSpeedRotate;
    private float _speedRotate;
    [SerializeField] private float _angleRotate;

    private void Start()
    {
        _speedRotate = Random.Range(_minSpeedRotate, _maxSpeedRotate);
    }

    private void FixedUpdate()
    {
        RotateObject(); 
    }

    private void RotateObject()
    {
        gameObject.transform.Rotate(0, _angleRotate * _speedRotate, 0);
    }
}
