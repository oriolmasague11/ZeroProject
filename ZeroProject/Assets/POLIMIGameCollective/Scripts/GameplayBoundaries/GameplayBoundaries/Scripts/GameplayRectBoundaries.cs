using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayRectBoundaries : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private static float _top;
    private static float _bottom;
    private static float _left;
    private static float _right;
    private static float _margin;
    
    public static float Top => _top + _margin;
    public static float Bottom => _bottom - _margin;
    public static float Left => _left - _margin;
    public static float Right => _right + _margin;
    public static float Margin => _margin;

    public static float Width => _right - _left;
    public static float Height => _top - _bottom;
    
    [SerializeField] private float margin = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ComputeBounds();
    }

    private void OnEnable()
    {
        ComputeBounds();
    }


    private void ComputeBounds()
    {
        Bounds bounds = _spriteRenderer.bounds;
        _top = bounds.max.y;
        _bottom = bounds.min.y;
        _left = bounds.min.x;
        _right = bounds.max.x;
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
