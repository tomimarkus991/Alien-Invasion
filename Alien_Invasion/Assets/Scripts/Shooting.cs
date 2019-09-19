using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timeBetweenShots;
    private float shotTime;

    public float bulletForce = 20f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time >= shotTime)
            {
                Shoot();
                shotTime = Time.time + timeBetweenShots;
            }
        }        
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
