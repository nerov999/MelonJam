using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float currentHealth;    
    public float damagePerSecond = 1f;  

    private bool isTakingDamage = false;
    private float damageTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        if (isTakingDamage)
        {
            damageTimer += Time.deltaTime;
            float damage = damagePerSecond * damageTimer;
            ApplyDamage(damage);
            damageTimer = 0f;
        }

        if (currentHealth <= 0)
        {
            HandleDeath(); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isTakingDamage = true;  
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isTakingDamage = false;  
        }
    }

    void ApplyDamage(float amount)
    {
        currentHealth -= amount; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  
        Debug.Log("Current Health: " + currentHealth); 
    }

    void HandleDeath()
    {
        Debug.Log("Player Died"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
