using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform playerTransform;

    private float _spawnZ = 0;
    private float _tileLength = 15f;
    public int amnTilesOnScreen = 7;

    void Start()
    {
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnGroundTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (_spawnZ - amnTilesOnScreen * _tileLength))
        {
            SpawnGroundTile();
        }
    }

    private void SpawnGroundTile()
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(this.transform);
        go.transform.position = Vector3.forward * _spawnZ;

        _spawnZ += _tileLength;
    }
}
