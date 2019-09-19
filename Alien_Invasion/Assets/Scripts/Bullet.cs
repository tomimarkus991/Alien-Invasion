using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float lifeTime;
    public GameObject explosion;
    private void Start()
    {
        //Destroy(gameObject, lifeTime);
        Invoke("DestroyBullet", lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
    void DestroyBullet()
    {
        Instantiate(explosion, transform.position, Quaternion.identity); // quat, et ei oleks rotationit
        Destroy(gameObject);
    }
}
