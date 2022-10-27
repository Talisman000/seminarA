using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMax = 5;
    [SerializeField] private float velocityMin = -5;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        var velocityX = Random.Range(velocityMin, velocityMax);
        var velocityZ = Random.Range(velocityMin, velocityMax);
        _rigidbody.velocity = new Vector3(velocityX, 0, velocityZ);
        var atan = Mathf.Atan2(velocityZ, velocityX);
        var angle = Mathf.Rad2Deg * atan;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
}