using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;  
    public HealthController playerHealth; 

    void Update()
    {
        if (playerHealth != null && healthBarFill != null)
        {
            float healthPercentage = playerHealth.currentHealth / playerHealth.maxHealth;
            healthBarFill.fillAmount = healthPercentage; 
        }
    }
}
