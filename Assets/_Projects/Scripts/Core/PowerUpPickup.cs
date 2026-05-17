using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    [SerializeField] private float duration = 10f; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("projectile"))
        {
            PlayerController player = GameObject.FindAnyObjectByType<PlayerController>();
            if (player != null)
            {
                player.ActivateDoubleShot(duration);
            }

            gameObject.SetActive(false); 
        }
    }
}