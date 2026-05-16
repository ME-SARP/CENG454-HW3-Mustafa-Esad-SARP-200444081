using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float damageToCore = 15f;
    
    private float currentHealth;
    private IMovementStrategy currentStrategy;

    public float CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        currentStrategy = new LinearMovement();
    }

    private void Update()
    {
        if (currentStrategy != null)
        {
            currentStrategy.ExecuteMovement(transform, moveSpeed);
        }
    }

    public void ChangeMovementStrategy(IMovementStrategy newStrategy)
    {
        currentStrategy = newStrategy;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " yok edildi!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnergyCore")
        {
            IDamageable coreDamageable = collision.GetComponent<IDamageable>();
            if (coreDamageable != null)
            {
                coreDamageable.TakeDamage(damageToCore);
                Destroy(gameObject);
            }
        }
    }
}