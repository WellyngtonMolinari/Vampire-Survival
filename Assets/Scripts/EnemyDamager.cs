using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime, growSpeed = 5f;
    private Vector3 targetSize;

    public bool shouldKnockback;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, lifeTime);

        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {   
        //to fade-in the animation of fireball
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);

        //to fade-out the animation of fireball
        lifeTime -= Time.deltaTime;
        
        if (lifeTime <= 0f)
        {
            targetSize = Vector3.zero;

            if (transform.localScale == Vector3.zero)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockback);
        }
    }

}
