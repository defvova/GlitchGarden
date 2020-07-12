using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float walkSpeed = 0f;
    private float health = 1f;
    private Animator animator;
    private GameObject currentTarget;

    [SerializeField] private GameObject deathVFX;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        var newVFX = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(newVFX, 1f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetMovementSpeed(float speed)
    {
        walkSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }
}