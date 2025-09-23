using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] float interactionTime;
    public bool interacted;
    public int Time;
    [SerializeField] int currentTime;
    bool interactable;
    [SerializeField] Image alert;
    [SerializeField] Image fillBar;
    float currentFill;
    void Start()
    {
        setInteractive();
        currentTime = 0;
        interacted = true;
        interactable = false;
        alert.enabled = false;
        currentFill = fillBar.GetComponent<Image>().fillAmount;
    }

    // Update is called once per frame
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
        if (alert.enabled && currentTime > -300 && currentTime < 0)
        {
            alert.GetComponent<Image>().color = new Color(0.8156863f, 0, 0);
        }
    }

    void setInteractive()
    {
        Time = (Random.Range(10, 1000));
    }

    void startInteraction()
    {
        alert.GetComponent<Image>().color = new Color(0.7484276f, 0.5275412f, 0.1671017f);
        alert.enabled = true;
        currentTime = -500;
        interacted = false;
        interactable = true;
        interactionTime = 0;
    }

    void Complete()
    {
        interactionTime = 0;
        alert.enabled = false;
        setInteractive();
        currentTime = 0;
        Debug.Log("Complete");
    }
}
