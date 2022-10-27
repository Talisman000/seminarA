using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> fishes;
    [SerializeField] private float spawnInterval;
    [SerializeField] private AnimationCurve spawnIntervalCurve;
    [SerializeField] private GameTimer gameTimer;
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
        UpdateIntervalCurveProgress();
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= spawnInterval)
        {
            var spawnPosition = new Vector3(
                Random.Range(spawnPosBegin.x, spawnPosEnd.x),
                Random.Range(spawnPosBegin.y, spawnPosEnd.y),
                Random.Range(spawnPosBegin.z, spawnPosEnd.z)
            );
            var obj = fishes[Random.Range(0, fishes.Count)];
            Instantiate(obj, spawnPosition, Quaternion.identity);
            _spawnTimer = 0;
        }
    }

    private void UpdateIntervalCurveProgress()
    {
        var progress = gameTimer.Timer / gameTimer.TimeG;
        spawnInterval = spawnIntervalCurve.Evaluate(progress);
    }
}