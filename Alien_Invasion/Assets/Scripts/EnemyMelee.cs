using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public float stopDistance;

    private float attackTime;

    public float attackSpeed;
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position,player.position) > stopDistance)
            {   // transform.position on current position ss target position
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                Vector3 direction = player.position - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                rb.rotation = angle;
                direction.Normalize();
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    // attack
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position; // melee enemy position enne kui ta hüppab playeri poole
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
