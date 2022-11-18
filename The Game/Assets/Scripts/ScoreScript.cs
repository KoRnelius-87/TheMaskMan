using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private float score;
    private TextMeshProUGUI TextMeshProUGUI;

    private void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //score += Time.deltaTime;
        TextMeshProUGUI.text = score.ToString("0");
    }

    public void Score(float scores)
    {
        score += scores;
    }
}
