using UnityEngine;

public class DoubleShotDecorator : WeaponDecorator
{
    public DoubleShotDecorator(IWeapon weaponToDecorate) : base(weaponToDecorate) { }

    public override void Fire(Vector3 spawnPosition, SimpleObjectPool bulletPool)
    {
        if (bulletPool == null) return;

        PlayerController player = GameObject.FindAnyObjectByType<PlayerController>();
        Quaternion currentRotation = player != null ? player.transform.rotation : Quaternion.identity;

        GameObject bullet1 = bulletPool.GetPooledObject();
        if (bullet1 != null)
        {
            Vector3 leftOffset = currentRotation * new Vector3(-0.25f, 0f, 0f);
            bullet1.transform.position = spawnPosition + leftOffset;
            bullet1.transform.rotation = currentRotation;
            bullet1.SetActive(true);
        }

        GameObject bullet2 = bulletPool.GetPooledObject();
        if (bullet2 != null)
        {
            Vector3 rightOffset = currentRotation * new Vector3(0.25f, 0f, 0f);
            bullet2.transform.position = spawnPosition + rightOffset;
            bullet2.transform.rotation = currentRotation;
            bullet2.SetActive(true);
        }

        Debug.Log("DEKORATOR ETKISI: Fareye dogru cift mermi ateslendi!");
    }
}