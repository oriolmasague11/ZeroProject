using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSquareControler : MonoBehaviour
{
    public float sizeRange = .2f;

    private void Start()
    {
        float minimumSize = 1f - sizeRange; 
        float maximumSize = 1f + sizeRange;
        float size = Random.Range(minimumSize, maximumSize);
        transform.localScale = new Vector3(size, size, transform.localScale.z);
    }
}
