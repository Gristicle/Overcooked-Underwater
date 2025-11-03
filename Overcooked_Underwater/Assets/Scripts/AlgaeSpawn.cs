using System.Collections;
using UnityEngine;

public class AlgaeSpawn : MonoBehaviour
{
    [SerializeField] GameObject algae;

    private void Awake()
    {
        StartCoroutine(spawnAlgae());
    }

    IEnumerator spawnAlgae()
    {
        yield return new WaitForSecondsRealtime(Random.Range(10, 50));
        Instantiate(algae, new Vector3(Random.Range(-26f, 26f), Random.Range(-18f, 7f), -4.03f), this.transform.rotation, this.transform);
    }
}
