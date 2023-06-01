using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    public GameObject deathEffect;

    public float pickupRange; // Added pickupRange property
    public float moveSpeed; // Added moveSpeed property

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PlayerStatController.instance.health[0].value;

        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
        }*/
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        // when player dies
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //time slowmo
            Time.timeScale = 0.2f;

            LevelManager.instance.EndLevel();

            Instantiate(deathEffect, transform.position, transform.rotation);

            SFXManager.instance.PlaySFX(3);
        }

        healthSlider.value = currentHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }
}
