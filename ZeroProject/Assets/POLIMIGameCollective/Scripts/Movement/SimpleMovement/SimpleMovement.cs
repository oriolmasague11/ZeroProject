using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    [Tooltip("If true the object moves only in four directionsy.")]
    [SerializeField] private bool canMoveInFourDirectionsOnly = true;
    
    [Tooltip("If true it uses GetAxis (instead of GetRawAxis()) which introduces inertia.")]
    [SerializeField] private bool moveWithInertia = true;
    
    private float _horizontalInput;
    private float _verticalInput;
    private bool _shouldMove;

    private void Update()
    {
        if (moveWithInertia)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            _verticalInput = Input.GetAxisRaw("Vertical");
        }

        if (canMoveInFourDirectionsOnly)
        {
            if (Mathf.Abs(_horizontalInput) > float.Epsilon)
                _verticalInput = 0;
        }

        _shouldMove = Mathf.Abs(_horizontalInput) > float.Epsilon || Mathf.Abs(_verticalInput) > float.Epsilon;

        if (_shouldMove)
        {
            transform.position += transform.right * (_horizontalInput * speed * Time.deltaTime) + 
                                  transform.up * (_verticalInput * speed * Time.deltaTime);
        }
    }
}
