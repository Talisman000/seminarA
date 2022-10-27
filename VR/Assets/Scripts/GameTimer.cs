using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float timeG = 60;
    private float _timer = 0;

    public float TimeG => timeG;
    public float Timer => _timer;

    [SerializeField] public TextMeshProUGUI timeText;


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGame) return;
        _timer += Time.deltaTime;
        UpdateText();
        if (_timer >= timeG)
        {
            _timer = timeG;
            UpdateText();
            playerController.GameOver();
        }
    }

    private void UpdateText()
    {
        timeText.text = $"Time: {timeG - _timer:00}";
    }
}
