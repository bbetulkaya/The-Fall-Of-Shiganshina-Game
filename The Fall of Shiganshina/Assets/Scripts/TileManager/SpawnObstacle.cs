using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float leftSide;
    public float rightSide;
    private float _spawnZDistance = 10;
    private int amontOfObstacleOnGround = 3;
    public GameObject[] obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObstacleAtGround(GameObject ground)
    {
        float groundLength = ground.transform.position.z;
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
        int randomX = Random.Range(-3, 3);
        return randomX;
    }
}
