using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(1, 9)] [SerializeField] int gameSpeed = 5;

    [SerializeField] int score;
    [SerializeField] int blockPoints = 83;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Pow(1.25f, gameSpeed - 5);
    }

    public void AddScore()
    {
        score += blockPoints;
    }
}
