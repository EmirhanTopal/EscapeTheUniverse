using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreboardManager : MonoBehaviour
{
    public int score;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void ScoreBoard(int increaseScoreCount)
    {
        score += increaseScoreCount;
        textMeshProUGUI.text = score.ToString();
    }

}
