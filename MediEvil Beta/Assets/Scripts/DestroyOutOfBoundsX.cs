using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = 10f;

    // Update is called once per frame
    void Update()
    {
        // Destroy ball if x position less than left limit
        if (transform.position.z > leftLimit)
        {
            Destroy(gameObject);
        } 

    }
}
