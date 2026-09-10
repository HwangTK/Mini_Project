using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRoom : MonoBehaviour
{
    [Header("스폰포인트")]
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private GameObject[] _itemPrefabs;

    private bool _isSpawned = false;

    void Start()
    {
        
    }



    void Update()
    {
        
    }


    public void SpawnItem()
    {
        if (_isSpawned)
        {
            return;
        }

        _isSpawned = true;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            int randomIndex = Random.Range(0, _itemPrefabs.Length);

            Instantiate(
                _itemPrefabs[randomIndex],
                _spawnPoints[i].position,
                _spawnPoints[i].rotation
            );
        }
    }
}
