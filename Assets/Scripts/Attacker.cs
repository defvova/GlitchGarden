using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float walkSpeed = 0f;
    private float health = 1f;

    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (!bullet) return;

        ProcessHit(bullet);
    }

    private void ProcessHit(Bullet bullet)
    {
        health -= bullet.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }
}