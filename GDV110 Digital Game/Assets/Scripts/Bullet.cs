﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GunHandler gun;
    public GunHandler.BulletType bulletType;

    // Start is called before the first frame update
    void Start()
    {
        // Define gun
        gun = GameObject.Find("Player").GetComponent<GunHandler>(); 

        // Bullet speed
        GetComponent<Rigidbody2D>().velocity = transform.right * gun.bulletSpeed;

        // Run KillBullet to ensure it dies in x amount of time
        StartCoroutine(KillBullet());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If it hits a solid object, start the gun function.
        if (col.gameObject.layer == 10)
        {
            gun.OnBulletHit(bulletType, transform.position, col.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    IEnumerator KillBullet()    // Travel until travel time is reached
    {
        yield return new WaitForSeconds(gun.bulletLife);
        Destroy(gameObject);
    }
}
