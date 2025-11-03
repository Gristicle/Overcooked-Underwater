using UnityEngine;

public class TurtleSwim : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 startPosition;
    float lerpValue;
    private void Awake()
    {
        startSwim();
    }

    void Update()
    {
        lerpValue += Random.Range(0.001f, 0.004f);
        this.transform.position = new Vector3(Mathf.Lerp(startPosition.x, targetPosition.x, lerpValue), Mathf.Lerp(startPosition.y, targetPosition.y, lerpValue), targetPosition.z);
        if(this.transform.position == targetPosition)
        {
            startSwim();
        }
    }

    void startSwim()
    {
        lerpValue = 0;
        startPosition = this.transform.position;
        targetPosition = new Vector3(Random.Range(26, -26), Random.Range(8, -18), -2);
    }
}
