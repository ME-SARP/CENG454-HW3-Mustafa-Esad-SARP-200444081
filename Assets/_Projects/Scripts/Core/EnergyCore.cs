using UnityEngine;

public class EnergyCore : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isDestroyed = false;

    public float CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        GameEvents.TriggerCoreHealthChanged(currentHealth, maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        if (isDestroyed) return;

        currentHealth -= damageAmount;
        
        if (currentHealth < 0) currentHealth = 0;

        GameEvents.TriggerCoreHealthChanged(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDestroyed = true;
        Debug.Log("Core Breach! Enerji çekirdeği yok edildi!");
        
        GameEvents.TriggerGameOver(false);
    }
}