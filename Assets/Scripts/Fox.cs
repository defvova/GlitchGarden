using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Animator animator;
    private Attacker attacker;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        Gravestone graveston = otherObject.GetComponent<Gravestone>();
        if (graveston) animator.SetTrigger("IsJumping");

        Defender defender = otherObject.GetComponent<Defender>();
        if (!graveston) attacker.Attack(otherObject, defender);
    }
}