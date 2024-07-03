using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int _healthRestore = 20;
    private Vector3 _spinRotationSpeed = new Vector3(0, 180, 0);

    private void Update()
    {
        transform.eulerAngles += _spinRotationSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damaged damaged = collision.GetComponent<Damaged>();

        if (damaged)
        {
            bool wasHealed = damaged.Heal(_healthRestore);
            if (wasHealed)
            {
                Destroy(gameObject);
            }
        }
    }
}