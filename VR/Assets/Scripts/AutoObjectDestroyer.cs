using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float deadZoneX = 30;
    [SerializeField] private float deadZoneZ = 20;

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(transform.position.x) > deadZoneX)
        {
            Destroy(gameObject);
        }

        if (Mathf.Abs(transform.position.z) > deadZoneZ)
        {
            Destroy(gameObject);
        }
    }
}
