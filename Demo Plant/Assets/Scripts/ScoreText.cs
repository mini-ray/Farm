using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        scoreText.text = score.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
