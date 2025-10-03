using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementMovement : MonoBehaviour
{
    public float speed = 5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += speed * Time.deltaTime * _transform.up;
    }
}
