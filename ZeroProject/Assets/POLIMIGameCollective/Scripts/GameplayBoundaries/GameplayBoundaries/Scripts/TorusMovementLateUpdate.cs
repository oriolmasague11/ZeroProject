using System;
using UnityEngine;

public class TorusMovementLateUpdate : MonoBehaviour
{
    
    [SerializeField] private bool useRectBoundaries = true;
    private void LateUpdate()
    {
        if (useRectBoundaries)
        {
            transform.position = GameplayRectBoundaries.UpdatePosition(transform.position);
        }
        else
        {
            transform.position = GameplayBoundaries.UpdatePosition(transform.position);
        }
    }
}
