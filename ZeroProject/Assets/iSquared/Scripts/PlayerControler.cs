using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10f;
    private float _horizontal; 
    private float _vertical;
    private Transform _transform; 
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _transform.position += speed * _horizontal * Time.deltaTime * _transform.right + 
                                speed * _vertical * Time.deltaTime * _transform.up;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("I have been hit by: " + other.name);
            Destroy(gameObject);
        }

        if (other.CompareTag("BlackSquare"))
        {
            Debug.Log("I have been hit by: " + other.name);
            Vector3 objectScale = other.gameObject.transform.localScale; 
            Vector3 playerScale = _transform.localScale;
            float objectArea = objectScale.x * objectScale.y;   
            float playerArea = playerScale.x * playerScale.y;

            playerArea += objectArea; 

            float sideLength = Mathf.Sqrt(playerArea);

            _transform.localScale = new Vector3(sideLength, sideLength, _transform.localScale.z);

            Destroy(other.gameObject);
        }
    }
}
