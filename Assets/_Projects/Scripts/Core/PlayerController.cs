using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private IWeapon currentWeapon;
    private SimpleObjectPool bulletPool;

    [SerializeField] private Transform firePoint; 
    private float powerUpTimer = 0f;
    private bool isPowerUpActive = false;

    private void Start()
    {
        currentWeapon = new StandardWeapon();

        SimpleObjectPool[] pools = GameObject.Find("_Managers").GetComponents<SimpleObjectPool>();
        foreach (var pool in pools)
        {
            if (pool.GetPooledObject().name.Contains("Projectile"))
            {
                bulletPool = pool;
                break;
            }
        }
    }

    private void Update()
    {
        if (Mouse.current != null)
        {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            mouseScreenPos.z = 10f; 
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            Vector2 lookDirection = (mouseWorldPos - transform.position).normalized;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }

        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            if (currentWeapon != null && bulletPool != null && firePoint != null)
            {
                currentWeapon.Fire(firePoint.position, bulletPool);
            }
        }

        if (isPowerUpActive)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0f)
            {
                currentWeapon = new StandardWeapon();
                isPowerUpActive = false;
                Debug.Log("POWER-UP BİTTİ: Standart silaha geri dönüldü.");
            }
        }
    }

    public void ActivateDoubleShot(float duration)
    {
        currentWeapon = new DoubleShotDecorator(currentWeapon);
        powerUpTimer = duration;
        isPowerUpActive = true;
        Debug.Log("POWER-UP AKTİF: Silah 10 saniyeliğine DoubleShotDecorator ile sarmalandı!");
    }
}