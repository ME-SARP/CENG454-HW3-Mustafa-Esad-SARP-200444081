using UnityEngine;

public abstract class WeaponDecorator : IWeapon
{
    protected IWeapon decoratedWeapon;

    public WeaponDecorator(IWeapon weaponToDecorate)
    {
        this.decoratedWeapon = weaponToDecorate;
    }

    public virtual void Fire(Vector3 spawnPosition, SimpleObjectPool bulletPool)
    {
        if (decoratedWeapon != null)
        {
            decoratedWeapon.Fire(spawnPosition, bulletPool);
        }
    }
}