using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float leftSide;
    public float rightSide;
    private float _spawnZDistance = 10f;
    private float _offsetZ = 10f;
    private int amontOfObstacleOnGround = 3;
    public GameObject[] obstaclePrefabs;

    public void SpawnObstacleAtGround(GameObject ground)
    {
        float groundLength = ground.transform.position.z + _offsetZ;
        float obstacleZPos = groundLength;

        for (int i = 0; i < amontOfObstacleOnGround; i++)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);

            GameObject obstacle;
            obstacle = Instantiate(obstaclePrefabs[randomIndex]) as GameObject;
            obstacle.transform.position = new Vector3(RandomObstaclePositions(), obstaclePrefabs[randomIndex].transform.position.y, obstacleZPos);
            obstacleZPos -= _spawnZDistance;
            obstacle.transform.SetParent(ground.transform);

        }


    }
    private int RandomObstaclePositions()
    {
        float chance = Random.Range(-1f, 1f);

        if (chance < 0f)
        {
            return -3;
        }
        else if (chance > 0f && chance < 0.5f)
        {
            return 0;
        }
        else
        {
            return 3;
        }
    }
}
