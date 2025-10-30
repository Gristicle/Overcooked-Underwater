using UnityEngine;

public class Algae : MonoBehaviour
{
    public void Caught(GameObject Player)
    {
        Debug.Log("Caught");
        Player.GetComponent<Rigidbody>().linearDamping = 20f;
        Player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void Released(GameObject Player)
    {
        Player.GetComponent<Rigidbody>().linearDamping = 4f;
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
}
