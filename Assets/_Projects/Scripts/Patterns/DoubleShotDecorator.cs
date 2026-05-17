using UnityEngine;

public class DoubleShotDecorator : WeaponDecorator
{
    public DoubleShotDecorator(IWeapon weaponToDecorate) : base(weaponToDecorate) { }

    public override void Fire(Vector3 spawnPosition, SimpleObjectPool bulletPool)
    {
        if (bulletPool == null) return;

        GameObject bullet1 = bulletPool.GetPooledObject();
        if (bullet1 != null)
        {
            bullet1.transform.position = spawnPosition + new Vector3(-0.25f, 0f, 0f);
            bullet1.transform.rotation = Quaternion.identity;
            bullet1.SetActive(true);
        }

        GameObject bullet2 = bulletPool.GetPooledObject();
        if (bullet2 != null)
        {
            bullet2.transform.position = spawnPosition + new Vector3(0.25f, 0f, 0f);
            bullet2.transform.rotation = Quaternion.identity;
            bullet2.SetActive(true);
        }

        Debug.Log("DEKORATÖR ETKİSİ: Çift mermi ateşlendi!");
    }
}