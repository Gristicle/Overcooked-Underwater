using System.Collections;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    float interactionTime;
    public bool interacted;
    public int Time;
    int currentTime;
    void Start()
    {
        setInteractive();
        currentTime = 0;
        interacted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime != Time)
        {
            currentTime++;
        }
        else
        {
            startInteraction();
        }
        if(interactionTime > 2)
        {
            do
            {
                interactionTime += 0.1f;
                Debug.Log("Interacted");
            }
            while (interacted);
        }
    }

    void setInteractive()
    {
        Time = (Random.Range(10, 1000));
    }

    void startInteraction()
    {
        interacted = false;
        interactionTime = 0;
        //StartCoroutine(Interacting());
    }

    /*IEnumerator Interacting()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            if (interacted)
            {
                interactionTime += 1f;
            }
        }
    }*/
}
