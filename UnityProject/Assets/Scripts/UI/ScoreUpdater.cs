using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {
    [SerializeField] TextMeshProUGUI display;

    void Start() {
        EventManager.instance.onScoreChanged += UpdateScore;
        display.text = "Score: 0";
    }

    void UpdateScore(int score) {
        display.text = "Score: " + score;
    }
}