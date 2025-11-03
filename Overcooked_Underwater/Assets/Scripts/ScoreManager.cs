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
        scoreMult += Time.deltaTime / 100;
        scoreCounter.text = new string($"Score: {score}");
    }

    public void updateScore()
    {
        score += Mathf.RoundToInt(30 * scoreMult);
    }
    public void shark()
    {
        StartCoroutine(SharkSubtractScore());
    }
    public void endShark()
    {
        StopAllCoroutines();
    }
    IEnumerator SharkSubtractScore()
    {
        yield return new WaitForSeconds(2f);
        score -= 15;
        StartCoroutine(SharkSubtractScore());
    }
    public void algae()
    {
        StartCoroutine(AlgaeSubtractScore());
    }
    public void stopAlgae()
    {
        StopAllCoroutines();
    }
    IEnumerator AlgaeSubtractScore()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 4f));
        score -= UnityEngine.Random.Range(1, 6);
        StartCoroutine(AlgaeSubtractScore());
    }
}