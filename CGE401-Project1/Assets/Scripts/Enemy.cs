using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Maile Fidale
* Project1
* player takes damage when hit by enemy bee, cool down
*/

public class Enemy : MonoBehaviour
{
    public HealthSystem healthSystem;

    public float hitCooldown = 1f;
    private float lastHitTime = -999f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem playerHealth = other.GetComponent<HealthSystem>();
            if (healthSystem != null && Time.time - lastHitTime > hitCooldown)
            {
                lastHitTime = Time.time; // reset hit timer
                healthSystem.TakeDamage();
            }
        }
    }
}
