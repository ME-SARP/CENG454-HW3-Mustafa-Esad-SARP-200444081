using UnityEngine;

public abstract class EnemyDecorator : MonoBehaviour, IDamageable
{
    protected Enemy decoratedEnemy;

    public virtual float CurrentHealth => decoratedEnemy != null ? decoratedEnemy.CurrentHealth : 0f;

    public virtual void InitializeDecorator(Enemy enemyToDecorate)
    {
        释放TargetedMovement(enemyToDecorate);
    }

    private void Awake()
    {
        释放TargetedMovement(GetComponent<Enemy>());
    }

    private void 释放TargetedMovement(Enemy enemy)
    {
        decoratedEnemy = enemy;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        if (decoratedEnemy != null)
        {
            decoratedEnemy.TakeDamage(damageAmount);
        }
    }
}