
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

using UnityEngine.AI;

public class SceneManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject obstaclePrefab;
    public GameObject targetPrefab;
    public int numObstacles = 5;
    public float minDistance = 2f;
    public float planeSize = 10f;
    private PlayerController playerController;

    private List<Vector3> occupiedPositions = new List<Vector3>();
    GameObject target;
    GameObject player;
    public GameObject gameCanvas;

    void Start()
    {

        SpawnPlayer();
        SpawnObstacles();
        SpawnTarget();
        playerController = player.GetComponent<PlayerController>();
        playerController.target = target.transform;
        playerController.GameCanVas = gameCanvas;
    }

    void SpawnPlayer()
    {
        player = Instantiate(playerPrefab);
        Vector3 randomPosition = GetRandomPositionOnPlane();
        player.transform.position = randomPosition;
        occupiedPositions.Add(randomPosition);
    }

    void SpawnObstacles()
    {
        for (int i = 0; i < numObstacles; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            Vector3 randomPosition = GetRandomPositionOnPlane();
            obstacle.transform.position = randomPosition;
            occupiedPositions.Add(randomPosition);

        }
    }

    void SpawnTarget()
    {
        target = Instantiate(targetPrefab);
        Vector3 randomPosition = GetRandomPositionOnPlane();
        target.transform.position = randomPosition;
        occupiedPositions.Add(randomPosition);

    }

    Vector3 GetRandomPositionOnPlane()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-planeSize / 2f, planeSize / 2f), 0f, Random.Range(-planeSize / 2f, planeSize / 2f)); // Adjust range as per your plane size
        while (IsPositionOccupied(randomPosition))
        {
            randomPosition = new Vector3(Random.Range(-planeSize / 2f, planeSize / 2f), 0f, Random.Range(-planeSize / 2f, planeSize / 2f));
        }
        return randomPosition;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        foreach (Vector3 occupiedPos in occupiedPositions)
        {
            if (Vector3.Distance(occupiedPos, position) < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScemeOne");
    }
}

