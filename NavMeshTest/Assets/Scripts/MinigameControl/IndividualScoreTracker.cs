using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndividualScoreTracker : MonoBehaviour
{
    [SerializeField] private string playerName;
    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    public bool canBeStolenFrom = true;

    public void GainPoints(int pointsGained)
    {
        score += pointsGained;
        scoreText.text = playerName + ": " + score;
    }
}
