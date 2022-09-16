using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCustomEventBehavior : MonoBehaviour
{
    [SerializeField]
    private Event _event;

    private void OnTriggerEnter(Collider other)
    {
        _event?.Raise(gameObject);
    }
}
