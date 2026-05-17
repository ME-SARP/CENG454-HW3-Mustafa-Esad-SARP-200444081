using UnityEngine;

public class StandardWeapon : IWeapon
{
    public void Fire(Vector3 spawnPosition, SimpleObjectPool bulletPool)
    {
        if (bulletPool == null) return;

        GameObject bullet = bulletPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = spawnPosition;
            bullet.transform.rotation = GameObject.FindAnyObjectByType<PlayerController>().transform.rotation; 
            bullet.SetActive(true); 
        }
    }
}