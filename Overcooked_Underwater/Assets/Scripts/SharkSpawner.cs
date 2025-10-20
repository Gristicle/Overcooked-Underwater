using System.Collections;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    [SerializeField] GameObject SharkPrefab;
    [SerializeField] int randomNumber;
    int currentValue = 0;
    public bool spawned;
    private void Awake()
    {
        SpawnTime();
    }

    void Update()
    {
        currentValue++;
        if(currentValue >= randomNumber && !spawned)
        {
            spawned = true;
            spawnShark();
        }
    }

    public void SpawnTime()
    {
        currentValue = 0;
        randomNumber = Random.Range(0, 2000);
        spawned = false;
    }

    void spawnShark()
    {
        Instantiate(SharkPrefab, this.transform.position, new Quaternion(0, 0.707f, 0, 0.707f), this.transform);
    }
}
