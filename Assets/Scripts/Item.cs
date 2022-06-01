using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float y = 1.5f;
    void FixedUpdate()
    {
        transform.Rotate(0f, 100 * y * Time.deltaTime, 0f);
    }
}