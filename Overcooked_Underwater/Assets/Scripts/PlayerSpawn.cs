using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    public Transform[] SpawnPoints;
    private int m_playerCount;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if(m_playerCount < SpawnPoints.Length)
        {
            playerInput.transform.position = SpawnPoints[m_playerCount].transform.position;
        }
        else
        {
            playerInput.transform.position = SpawnPoints[0].transform.position;
        }
        m_playerCount++;
    }
}
