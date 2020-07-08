using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private float bulletSpeed = 10f;

    private Vector2 bulletMotion = new Vector2(0, 0);

    private void Start()
    {
        bulletMotion.x = bulletSpeed * Time.deltaTime;
    }

    public void Fire()
    {
        var newBullet = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = bulletMotion;
    }
}