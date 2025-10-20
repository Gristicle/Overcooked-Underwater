using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactive : MonoBehaviour
{
    public float interactionTime;
    public bool interacted;
    public int Time;
    [SerializeField] int currentTime;
    bool interactable;
    [SerializeField] Image alert;
    [SerializeField] Image fillBar;
    float currentFill;
    public int requiredTool;
    [SerializeField] TMP_Text Tool;
    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Start()
    {
        setInteractive();
        currentTime = 0;
        interacted = true;
        interactable = false;
        alert.enabled = false;
        currentFill = fillBar.GetComponent<Image>().fillAmount;
    }

    void Update()
    {
        fillBar.GetComponent<Image>().fillAmount = interactionTime/2;
        if (currentTime != Time)
        {
            currentTime++;
        }
        else
        {
            startInteraction();
        }
        if (interacted && interactable)
        {
            interactionTime += 0.01f;
            if (interactionTime >= 2)
            {
                interactable = false;
                Complete();
            }
        }
        if (alert.enabled && currentTime > -500 && currentTime < 0)
        {
            alert.GetComponent<Image>().color = new Color(0.8156863f, 0, 0);
        }
    }

    void setInteractive()
    {
        Time = (Random.Range(100, 3000));
        chooseTool();
    }

    void startInteraction()
    {
        this.GetComponent<BoxCollider>().enabled = true;
        alert.GetComponent<Image>().color = new Color(0.7484276f, 0.5275412f, 0.1671017f);
        Tool.text = new string($"{requiredTool}");
        alert.enabled = true;
        currentTime = -2000;
        interacted = false;
        interactable = true;
        interactionTime = 0;
    }

    void Complete()
    {
        scoreManager.updateScore();
        Tool.text = new string("");
        interactionTime = 0;
        alert.enabled = false;
        setInteractive();
        currentTime = 0;
        Debug.Log("Complete");
    }

    void chooseTool()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        int Required = Random.Range(0, 2);
        if (Required == 1)
        {
            requiredTool = Random.Range(1, 3);
        }
        else
        {
            requiredTool = 0;
        }
    }
}
