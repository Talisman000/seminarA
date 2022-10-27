using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float autoDestroyTime;
    [SerializeField] private float startRainTime;
    [SerializeField] private ParticleSystem rain;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayMethod(startRainTime, () =>
        {
            rain.Play();
        }));
        Destroy(gameObject, autoDestroyTime);
    }

    IEnumerator DelayMethod(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}