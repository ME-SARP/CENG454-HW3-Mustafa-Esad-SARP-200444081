using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifeTime = 3f; 
    
    private float currentLifeTimer;

    private void OnEnable()
    {
        currentLifeTimer = lifeTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        currentLifeTimer -= Time.deltaTime;
        if (currentLifeTimer <= 0f)
        {
            gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.gameObject.name.Contains("TestEnemy"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage); 
            }

            gameObject.SetActive(false); 
        }
        
        else if (collision.gameObject.name.Contains("PowerUpPickup"))
        {
            PowerUpPickup pickup = collision.GetComponent<PowerUpPickup>();
            if (pickup != null)
            {
                gameObject.SetActive(false); 
            }
        }
    }
}