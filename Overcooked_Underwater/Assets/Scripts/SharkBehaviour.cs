using UnityEngine;

public class SharkBehaviour : MonoBehaviour
{
    [SerializeField] GameObject highlight;
    ScoreManager scoreManager;
    bool interacted;
    [SerializeField] Vector3 position;
    float lerpValue;
    private void Awake()
    {
        interacted = false;
        highlight.SetActive(true);
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.shark();
    }

    void Update()
    {
        if (!interacted)
        {
            lerpValue += 0.001f;
        }
        else
        {
            highlight.SetActive(false);
        }
        this.transform.position = new Vector3(Mathf.Lerp(0, 4, lerpValue), Mathf.Lerp(0, -18, lerpValue), -2);
    }

    public void Reject()
    {
        scoreManager.endShark();
        lerpValue = 0;
        interacted = true;
        GetComponentInParent<SharkSpawner>().SpawnTime();
        Destroy(this.gameObject);
    }
}
