using UnityEngine;

public class EliteEnemyDecorator : EnemyDecorator
{
    [SerializeField] private float bonusHealth = 20f;
    [SerializeField] private Color eliteColor = Color.magenta; 

    private void Start()
    {
        if (decoratedEnemy != null)
        {
            decoratedEnemy.TakeDamage(-bonusHealth); 
            SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
            if (sRenderer != null)
            {
                sRenderer.color = eliteColor;
            }
            
            Debug.Log(gameObject.name + " DEKORATÖR EKLENDİ: Elite seviyeye yükseltildi! +20 Can.");
        }
    }
}