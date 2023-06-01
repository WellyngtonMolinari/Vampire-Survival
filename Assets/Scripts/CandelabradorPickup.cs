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

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeBetweenChecks;
                if (Vector3.Distance(transform.position, player.position) < player.GetComponent<PlayerController>().pickupRange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.GetComponent<PlayerController>().moveSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealthController.instance.Heal(healAmount);

            Destroy(gameObject);
        }
    }
}
