using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandelabradorPickup : MonoBehaviour
{
    public int healAmount = 1;

    private bool movingToPlayer;
    public float moveSpeed;

    public float timeBetweenChecks = .2f;
    private float checkCounter;

    private PlayerHealthController playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = PlayerHealthController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerHealth.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenChecks;
                if (Vector3.Distance(transform.position, playerHealth.transform.position) < playerHealth.pickupRange)
                {
                    movingToPlayer = true;
                    moveSpeed += playerHealth.moveSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth.Heal(healAmount);

            Destroy(gameObject);
        }
    }
}
