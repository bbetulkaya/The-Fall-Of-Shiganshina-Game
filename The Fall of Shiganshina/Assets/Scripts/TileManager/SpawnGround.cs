using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform playerTransform;

    private float _spawnZ = -15;
    private float _safeZone = 30f;
    private float _tileLength = 30f;
    private int _lastPrefabIndex = 0;
    public int amnTilesOnScreen = 5;

    private List<GameObject> _activeTiles;

    void Start()
    {
        _activeTiles = new List<GameObject>();
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnGroundTile(0);
            }
            else
            {
                SpawnGroundTile();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerTransform.position.z - _safeZone) > (_spawnZ - amnTilesOnScreen * _tileLength))
        {
            SpawnGroundTile();
            DeleteGroundTile();
        }
    }

    private void SpawnGroundTile(int prefabIndex = -1)
    {
        GameObject go;

        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(this.transform);
        go.transform.position = Vector3.forward * _spawnZ;
        _activeTiles.Add(go);

        _spawnZ += _tileLength;
    }

    private void DeleteGroundTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        // If there is only one ground tile return first prefab
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = _lastPrefabIndex;
        while (randomIndex == _lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        _lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
