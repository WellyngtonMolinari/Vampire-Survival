using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5f;

    public float knockBackTime = .5f;
    private float knockBackCounter;

    public int expToGive = 1;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform;
        target = PlayerHealthController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /* THIS CODE STOPS EVERYONE AFTER PLAYER DIES
        if (PlayerController.instance.gameObject.activeSelf == true)
        {*/
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if (moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2;
            }

            if (knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * .5f);
            }
        }
        theRB.velocity = (target.position - transform.position).normalized * moveSpeed;

        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
        //}
        /*else
        {
            theRB.velocity = Vector2.zero;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);

            ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockback)
    {
        TakeDamage(damageToTake);

        if (shouldKnockback == true)
        {
            knockBackCounter = knockBackTime;
        }
    }
}
