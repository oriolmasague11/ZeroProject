using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using POLIMIGameCollective;

public class GameplayBoundaries : MonoBehaviour
{
    [Serializable]
    public struct Boundaries
    {
        public Transform top;
        public Transform bottom;
        public Transform left;
        public Transform right;
    }

    private static float _top;
    private static float _bottom;
    private static float _left;
    private static float _right;
    private static float _margin;
    
    [SerializeField] private Boundaries gameplayBoundaries;
    [SerializeField] private float margin = 0;
    
    private void OnEnable()
    {
        _top = gameplayBoundaries.top.transform.position.y;
        _bottom = gameplayBoundaries.bottom.transform.position.y;
        _left = gameplayBoundaries.left.transform.position.x;
        _right = gameplayBoundaries.right.transform.position.x;
        _margin = margin;
    }

    public static Vector3 UpdatePosition(Vector3 position)
    {
        Vector3 updatedPosition = position;

        if (position.y > _top + _margin)
            updatedPosition.y = _bottom - _margin;
        if (position.y < _bottom - _margin)
            updatedPosition.y = _top + _margin;

        if (position.x > _right + _margin)
            updatedPosition.x = _left - _margin;
        if (position.x < _left - _margin)
            updatedPosition.x = _right + _margin;

        return updatedPosition;
    }
}
