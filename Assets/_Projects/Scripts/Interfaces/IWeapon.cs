using UnityEngine;

public interface IWeapon
{
    void Fire(Vector3 spawnPosition, SimpleObjectPool bulletPool);
}