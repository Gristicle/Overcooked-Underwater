using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreCounter;
    public int score;
    float scoreMult;


    void Start()
    {
        scoreMult = 0;
        score = 0;
    }

    private void Update()
    {
        scoreMult += Time.deltaTime / 10;
        scoreCounter.text = new string($"Score: {score}");
    }

    public void updateScore()
    {
        score += Mathf.RoundToInt(30 * scoreMult);
    }
    public void shark()
    {
        StartCoroutine(SubtractScore());
    }
    public void endShark()
    {
        StopAllCoroutines();
    }
    IEnumerator SubtractScore()
    {
        yield return new WaitForSeconds(2f);
        score -= 1;
        StartCoroutine(SubtractScore());
    }
}