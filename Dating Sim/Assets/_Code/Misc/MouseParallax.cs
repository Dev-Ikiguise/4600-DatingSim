using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParallax : MonoBehaviour
{
    public float speed = 0.1f;

    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        float x = (Input.mousePosition.x / Screen.width) - 0.5f;
        float y = (Input.mousePosition.y / Screen.height) - 0.5f;

        transform.position = _startPos + new Vector3(x * speed, y * speed, 0);
    }
}
