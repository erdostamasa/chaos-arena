using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardRow : MonoBehaviour {
    [SerializeField] TextMeshProUGUI positionDisplay;
    [SerializeField] TextMeshProUGUI nameDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    public void Initialize(int pos, string playerName, int score) {
        positionDisplay.text = pos.ToString();
        nameDisplay.text = playerName;
        scoreDisplay.text = score.ToString();
    }
}