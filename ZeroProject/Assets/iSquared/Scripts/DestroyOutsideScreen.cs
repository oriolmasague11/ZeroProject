using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esta molt guapo que el codi sigui aixi de reusable */
public class DestroyOutsideScreen : MonoBehaviour
{
    public float outerLimits = 12f;

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(transform.position.x) > outerLimits) || 
            (Mathf.Abs(transform.position.y) > outerLimits))
        {
            Destroy(gameObject);
        }
        
    }
}
