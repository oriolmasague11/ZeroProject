using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerControler _playerControler;
    private Transform _transform;

    private void Awake()
    {
        _playerControler = GetComponent<PlayerControler>();
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("RedPowerUp"))
        {
            Debug.Log("I have been hit by " + other.name);
        }

        if (other.CompareTag("BlackPowerUp"))
        {
            Debug.Log("I have been hit by " + other.name);
        }

        if (other.CompareTag("RedSquare"))
        {
            Debug.Log("I have been hit by " + other.name);
            Destroy(gameObject);
        }

        if (other.CompareTag("BlackSquare"))
        {
            Debug.Log("I have been hit by " + other.name);
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
