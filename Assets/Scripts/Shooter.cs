using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;

    private Animator animator;
    private EnemySpawner myLaneSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        animator.SetBool("IsAttacking", IsAttackingInLane());
    }

    public void Fire()
    {
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
    }

    private void SetLaneSpawner()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (GetIsCloseEnough(spawner)) myLaneSpawner = spawner;
        }
    }

    private bool GetIsCloseEnough(EnemySpawner spawner)
    {
        return Mathf.Abs(Mathf.RoundToInt(spawner.transform.position.y) - Mathf.RoundToInt(transform.position.y)) <= Mathf.Epsilon;
    }

    private bool IsAttackingInLane()
    {
        return myLaneSpawner && myLaneSpawner.transform.childCount > 0;
    }
}