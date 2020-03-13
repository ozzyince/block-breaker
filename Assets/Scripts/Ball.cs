using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        distance = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.realtimeSinceStartup;
        var angle = Mathf.Pow(-1, Mathf.FloorToInt(time) % 2) * (45 - (time - Mathf.Floor(time)) * 90);
        transform.position = paddle.transform.position + Quaternion.Euler(0, 0, angle) * distance;
    }
}
