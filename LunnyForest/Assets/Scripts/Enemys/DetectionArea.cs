using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DetectionArea : MonoBehaviour
{
    private Collider2D _collider2D;
    public List<Collider2D> detectedColliders = new List<Collider2D>();

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        detectedColliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        detectedColliders.Remove(other);
    }
}
