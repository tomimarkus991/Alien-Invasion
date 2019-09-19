using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float lifeTime;
    public GameObject explosion;
    public int damage;
    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }
    void DestroyBullet()
    {      
        Destroy(gameObject);
        // quat, et ei oleks rotationit
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
            DestroyBullet();
        }
    }
}
