using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouv : MonoBehaviour
{
    public float amplitude = 3.0f;
    public float speed = 2.0f;

    private float startY;
    private bool movingUp = true;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startY + amplitude)
                movingUp = false;
        }
        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= startY - amplitude)
                movingUp = true;
        }
    }
}
