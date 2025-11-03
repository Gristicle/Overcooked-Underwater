using System.Collections;
using UnityEngine;

public class Algae : MonoBehaviour
{
    public int amountCaught;
    Vector3 lerpLocation;
    Vector3 startLocation;
    ScoreManager scoreManager;
    GameObject stuckPlayer;
    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        chooseLocation();
    }

    void chooseLocation()
    {
        startLocation = this.transform.position;
        lerpLocation = new Vector3(Random.Range(-26f, 26f), Random.Range(-18f, 7f), this.transform.position.z);
        StartCoroutine(moveAlgae());
    }

    private void Start()
    {
        amountCaught = 0;
    }

    public void Caught(GameObject Player)
    {
        Player.GetComponent<PlayerMovement>().algae = this.gameObject;
        amountCaught++;
        if (amountCaught == 1)
        {
            stuckPlayer = Player;
            scoreManager.algae();
            Debug.Log("Caught");
            Player.GetComponent<Rigidbody>().linearDamping = 20f;
            Player.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    public void Released(GameObject Player)
    {
        scoreManager.stopAlgae();
        stuckPlayer.GetComponent<PlayerMovement>().algae = null;
        stuckPlayer.GetComponent<Rigidbody>().linearDamping = 4f;
        stuckPlayer.GetComponent<PlayerMovement>().enabled = true;
        stuckPlayer = null;
        Destroy(this.gameObject);
    }

    public void Removed(GameObject Player)
    {
        StopCoroutine(moveAlgae());
        Released(Player);
    }

    IEnumerator moveAlgae()
    {
        for (float f = 0; f < 1; f += 0.0001f)
        {
            this.transform.position = new Vector3(Mathf.Lerp(startLocation.x, lerpLocation.x, f), Mathf.Lerp(startLocation.y, lerpLocation.y, f), this.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        chooseLocation();
    }
}
