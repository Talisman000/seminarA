using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    [SerializeField] private float spawnInterval;
    private float _spawnTimer = 0;

    [SerializeField] private Vector3 spawnPosBegin;

    [SerializeField] private Vector3 spawnPosEnd;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval)
        {
            var spawnPosition = new Vector3(
                Random.Range(spawnPosBegin.x, spawnPosEnd.x),
                Random.Range(spawnPosBegin.y, spawnPosEnd.y),
                Random.Range(spawnPosBegin.z, spawnPosEnd.z)
            );
            Instantiate(fish, spawnPosition, Quaternion.identity);
            _spawnTimer = 0;
        }
    }
}