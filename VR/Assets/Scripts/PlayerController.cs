using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ContinuousMoveProviderBase continuousMoveProvider;
    [SerializeField] private Collider coll;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void Start()
    {
        GameManager.isGame = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameOver();
    }

    public void GameOver()
    {
        GameManager.isGame = false;
        continuousMoveProvider.enabled = false;
        coll.enabled = false;
        characterController.enabled = false;
        gameOverText.gameObject.SetActive(true);
    }
}
