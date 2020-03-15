using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;

    private Paddle paddle;
    private Vector2 distance;
    private AudioSource audioSource;
    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        distance = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted) return;
        LockBallToPaddle();
        LaunchOnClick();
    }

    private void LaunchOnClick()
    {
        hasStarted = Input.GetMouseButtonDown(0);
        if (!hasStarted) return;
        GetComponent<Rigidbody2D>().velocity = GetVelocity();
    }

    private void LockBallToPaddle()
    {
        transform.position = (Vector2)paddle.transform.position + GetVector();
    }

    private Vector2 GetVector()
    {
        var time = Time.realtimeSinceStartup;
        var angle = Mathf.Pow(-1, Mathf.FloorToInt(time) % 2) * (45 - (time - Mathf.Floor(time)) * 90);
        return Quaternion.Euler(0, 0, angle) * distance;
    }

    private Vector2 GetVelocity()
    {
        return GetVector() * 20;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasStarted) return;
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
