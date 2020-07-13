using System;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float walkSpeed = 0f;

    private Animator animator;
    private GameObject currentTarget;

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

        Health health = GetComponent<Health>();
        if (!health) return;

        health.DealDamage(bullet.GetDamage());
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

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();

        if (!health) return;
        health.DealDamage(damage);
        animator.SetBool("IsAttacking", health.HasHealth());
    }
}