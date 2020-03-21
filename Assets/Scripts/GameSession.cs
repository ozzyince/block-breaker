using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(1, 9)] [SerializeField] int gameSpeed = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int score;
    [SerializeField] int blockPoints = 83;

    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Pow(1.25f, gameSpeed - 5);
    }

    public void AddScore()
    {
        score += blockPoints;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
