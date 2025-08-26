using UnityEngine;
using System;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;
    
    [Header("Reference")]
    public HealthBarScriptSoapy healthBar;
    public GameObject deathPanel;
    private HealthManager health;
    

    void Start()
    {
        currentHealth = maxHealth;

        
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        
        health = GetComponent<HealthManager>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        int damageAmount = 1;

        
        if (other.CompareTag("Dusty"))
        {
            health.TakeDamage(damageAmount);
            SFXManager.instance.PlaySFX("GetHit");
        }
        else if (other.CompareTag("Bactino"))
        {
            Destroy(other.gameObject);
            PointManager.Instance.AddScore(10);
            SFXManager.instance.PlaySFX("Kill");
        }
        else if (other.CompareTag("Destroy"))
        {
            GameOver();
        }
    }
   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " kena damage! Sisa HP: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

  
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log(gameObject.name + " HP sekarang: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    void GameOver()
    {
        Debug.Log(gameObject.name + " GAME OVER!");
        deathPanel.SetActive(true);
        ButtonManager.isPaused = true;
        gameObject.SetActive(false);
    }
}