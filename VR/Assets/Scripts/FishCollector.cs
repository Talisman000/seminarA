using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            var fishCore = other.GetComponent<FishCore>();
            if (fishCore == null) return;
            scoreManager.AddScore(fishCore.Score);
        }
    }
}
